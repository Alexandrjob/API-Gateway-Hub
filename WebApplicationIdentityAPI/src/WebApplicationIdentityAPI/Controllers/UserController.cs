using JwtIdentity.Models.Interfaces;
using JwtIdentity.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationIdentityAPI.Controllers;

[ApiController]
[Route("/api/identity/user")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly JwtTokenService _jwtTokenService;

    public UserController(ILogger<UserController> logger, JwtTokenService jwtTokenService)
    {
        _logger = logger;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost]
    public IActionResult Authentication([FromBody] User user)
    {
        _logger.LogInformation("Get request, email:{Email}", user.Email);

        if (user.Email != "Sasha")
            return BadRequest(user);

        var token = _jwtTokenService.GetToken(user);
        _logger.LogInformation("Generate token, token:{Token}", token);
        return Ok(token);
    }

    public class User : IIdentityUser
    {
        public string Email { get; set; }
    }
}