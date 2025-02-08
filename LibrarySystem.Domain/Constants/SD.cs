
namespace Kader_System.Domain.Constants;

public static class SD
{
    public static class Modules
    {
        public const string Auth = "Auth";
        public const string Setting = "Setting";
        public const string EmployeeRequest = "Employee_Request";
        public const string HR = "HR";
        public const string Trans = "Trans";
        public const string V1 = "v1";
        public const string Bearer = "Bearer";
        public const string CompanyContracts = "Company Contracts";
        public const string CompanyLicesnses = "Company Licesnses";
        public const string Employees = "Employees";
        public const string Interview = "Interview";

    }
    public static class UserRole
    {

        public static string Id = "0ffa8112-ba0d-4416-b0ed-992897ac896e";
        public static string RoleNameInAr = "مستخدم";
        public static string RoleNameInEn = "User";
    }
    public static class Roles
    {
        public const string Administrative = "Administrative";
        public const string User = "User";
        public const string SuperAdmin = "SuperAdmin";

    }
    public static class RequestClaims
    {
        public const string Permission = "Permission";
        public const string RolePermission = "RolePermission";
        public const string UserPermission = "UserPermission";
        public const string DomainRestricted = "DomainRestricted";
        public const string Company = "CompanyId";
        public const string UserId = "uid";
        public const string Titles = "Titles";
        public const string Mobile = "Mobile";
        public const string Image = "Image";
        public const string Email = "Email";
        public const string FullName = "FullName";
        public const string CurrentCompany = "CurrentCompany";
        public const string CurrentTitle = "CurrentTitle";

    }
    public static class Shared
    {
        public const string LibrarySystem = "LibrarySystem";
        public const string LibrarySystemConnection = "LibrarySystemConnection";
        public const string JwtSettings = "JwtSettings";
        public const string AccessToken = "access_token";
        public const string CorsPolicy = "CorsPolicy";
        public const string Development = "Development";
        public const string Production = "Production";
        public const string Productions = "Productions";
        public const string Local = "Local";
        public const string Notify = "/notify";
        public static string[] Cultures = ["en-US", "ar-EG"];
        public const string Resources = "Resources";
        public const string Company = "Company";
        public const string Department = "Department";
        public const string Task = "Task";
        public const System.IO.Compression.CompressionLevel CompressionLevel = System.IO.Compression.CompressionLevel.Fastest;
    }
    public static class ApiRoutes
    {

    }

}

