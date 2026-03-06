namespace SmartFinanceAI.Application.DTO
{
    public record RegisterRequest(string Email, string Password, string FullName);
    public record LoginRequest(string Email, string Password);
    public record GoogleLoginRequest(string IdToken);
    public record AuthResponse(string AccessToken, string RefreshToken);
}
