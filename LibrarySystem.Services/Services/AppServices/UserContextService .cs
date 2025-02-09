using LibrarySystem.Services.IServices.AppServices;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static LibrarySystem.Domain.Constants.SD;

namespace LibrarySystem.Services.Services.AppServices
{
    public class UserContextService(IHttpContextAccessor httpContextAccessor) : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private int? _cachedUserId;

        public int? UserId
        {
            get
            {
                if (_cachedUserId.HasValue)
                {
                    return _cachedUserId;
                }
                var context = _httpContextAccessor.HttpContext;
                if (context?.User == null)
                {
                    return null;
                }
                var userIdClaim = context.User.FindFirstValue(RequestClaims.UserId);
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return null;
                }
                if (int.TryParse(userIdClaim, out int userId))
                {
                    _cachedUserId = userId;
                    return userId;
                }
                return null;
            }
        }
    }
}
