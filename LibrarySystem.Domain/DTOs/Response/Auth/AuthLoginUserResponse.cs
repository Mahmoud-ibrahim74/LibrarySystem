﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Domain.DTOs.Response.Auth;

public class AuthLoginUserResponse
{
    public string UserName { get; set; } = string.Empty;
    public List<string> RoleNames { get; set; } = new();
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
    public DateTime ExpiresOn { get; set; }
    public int Company_Id { get; set; }
    public int? Department_Id { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    [JsonIgnore]
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
}
