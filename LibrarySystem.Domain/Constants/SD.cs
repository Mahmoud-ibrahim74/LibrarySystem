namespace LibrarySystem.Domain.Constants;

public static class SD
{
    public static class Modules
    {
        public const string Auth = "Auth";
        public const string V1 = "v1";
        public const string Bearer = "Bearer";

    }
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";

    }
    public static class RequestClaims
    {
        public const string UserId = "uid";
        public const string Titles = "Titles";
        public const string Mobile = "Mobile";
        public const string Image = "Image";
        public const string Email = "Email";
        public const string FullName = "FullName";

    }
    public static class Shared
    {
        public const string LibrarySystem = "LibrarySystem";
        public const string LibrarySystemConnection = "LibrarySystemConnection";
        public const string JwtSettings = "JwtSettings";
        public const int JwtExpirationDaysCount = 2;
        public const string AccessToken = "access_token";
        public const string CorsPolicy = "CorsPolicy";
        public const string Development = "Development";
        public const string Notify = "/notify";

        public const string Production = "Production";
        public const string Productions = "Productions";
        public const string Resources = "Resources";
    }
    public static class ApiRoutes
    {
        public static class Users
        {
            public const string GetAllUsers = "Users/GetAll";
            public const string LoginUser = "Users/Login";
            public const string GetUserById = "Users/{id}";
            public const string AddUser = "Users/Add";
            public const string DeleteUser = "Users/Delete/{id}";

        }
        public static class Roles
        {
            public const string GetAllRoles = "Roles/GetAll";
            public const string AddRole = "Roles/Add";
            public const string UpdateRole = "Roles/Update/{id}";
            public const string DeleteRole = "Roles/Delete/{id}";
        }
        public static class UserRoles
        {
            public const string AddUserRole = "UserRoles/Add";
            public const string DeleteUserRole = "UserRoles/Delete";
        }
    }

}

