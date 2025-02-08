using LibrarySystem.DataAccess.Interfaces;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystem.Domain.Options;
using LibrarySystem.Services.IServices;
using LibrarySystem.Services.Services;
using LibrarySystemAPI.DataAccess.Context;
using LibrarySystemAPI.DataAccess.Models.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static LibrarySystem.Domain.Constants.SD;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

#region IdentityConfig
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<LibrarySystemDbContext>()
.AddDefaultTokenProviders();
#endregion


builder.Services.AddDbContext<LibrarySystemDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString(Shared.LibrarySystemConnection),
     b => b.MigrationsAssembly(typeof(LibrarySystemDbContext).Assembly.FullName)));



#region JWT config

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(Shared.JwtSettings));

var jwtSettings = new JwtSettings();
builder.Configuration.Bind(nameof(jwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidIssuer = jwtSettings.Issuer,
        ClockSkew = TimeSpan.Zero
    };

    o.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query[Shared.AccessToken];

            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments(Shared.Notify))
            {
                context.Request.Headers.Authorization = accessToken;
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});

#endregion


#region Swagger config

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc(Modules.Auth, new OpenApiInfo
    {
        Title = $"{Shared.LibrarySystem} {Modules.Auth}",
        Version = Modules.V1
    });
    x.AddSecurityDefinition(Modules.Bearer, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field Like => Bearer yourToken....",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = Modules.Bearer,
        BearerFormat = "Bearer",

    });
});


#endregion


#region DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint($"/swagger/{Modules.Auth}/swagger.json", "Auth_Management v1");
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
