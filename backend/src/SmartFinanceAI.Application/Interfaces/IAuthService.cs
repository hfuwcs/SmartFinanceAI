using SmartFinanceAI.Domain.Entities;

namespace SmartFinanceAI.Infrastructure.Identity
{
    public interface IAuthService
    {
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
        Task<ApplicationUser?> VerifyGoogleTokenAsync(string idToken);
    }
}