using LibrarySystemAPI.DataAccess.Context;
using LibrarySystemAPI.DataAccess.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Kader_System.Domain.Constants.SD;

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






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
