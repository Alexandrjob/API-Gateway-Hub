using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAPI.Controllers;

[ApiController]
[Route("/api/personality/user")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult GetAge([FromBody] User user)
    {
        _logger.LogInformation("Get request, email:{Email}", user.Email);

        if (user.Email != "Sasha")
            return BadRequest();

        var random = new Random();
        return Ok(random.Next(0, 100));
    }

    public class User
    {
        public string Email { get; set; }
    }
}