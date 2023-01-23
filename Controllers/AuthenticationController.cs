using cinema_warmup_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace cinema_warmup_app.Controllers;

[Produces("application/json")]
[Route("api/Auth")]
public class AuthenticationController : Controller
{
    private readonly CinemadbContext _context;
    
    public AuthenticationController(CinemadbContext context)
    {
        _context = context;
    }
    
    // GET
    [HttpPost]
    public async Task<ActionResult<User>> Login([FromBody] User user)
    {
        Console.WriteLine($"Authenticating... ({user.Email} : {user.Password})");
        if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password)) return NotFound();

        User? userResult = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
        
        if (userResult == null)
        {
            Console.WriteLine("User not found");
            return NotFound();
        }

        Console.WriteLine("User OK");
        return Ok(userResult);
    }
}
