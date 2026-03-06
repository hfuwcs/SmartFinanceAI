using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartFinanceAI.Application.DTO;
using SmartFinanceAI.Domain.Entities;
using SmartFinanceAI.Infrastructure.Identity;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AuthService _authService;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AuthService authService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = new ApplicationUser { UserName = request.Email, Email = request.Email, FullName = request.FullName };
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(new { Message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) return Unauthorized("Invalid credentials");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded) return Unauthorized("Invalid credentials");

        var token = await _authService.GenerateJwtTokenAsync(user);
        return Ok(new AuthResponse(token, "refresh_token_placeholder"));
    }
    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        var user = await _authService.VerifyGoogleTokenAsync(request.IdToken);
        if (user == null) return Unauthorized("Invalid Google Token");

        var token = await _authService.GenerateJwtTokenAsync(user);
        return Ok(new AuthResponse(token, "refresh_token_placeholder"));
    }

    // Test endpoint to verify JWT authentication and retrieve user profile
    [Authorize]
    [HttpGet("me")]
    public IActionResult GetProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = User.FindFirstValue(ClaimTypes.Email);
        var fullName = User.FindFirstValue("FullName");

        return Ok(new
        {
            UserId = userId,
            Email = email,
            FullName = fullName
        });
    }
}