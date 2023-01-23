using cinema_warmup_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cinema_warmup_app.Controllers;

[Produces("application/json")]
[Route("api/Users")]
public class UserController : Controller
{
    private readonly CinemadbContext _context;

    public UserController(CinemadbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        Console.WriteLine("GettingUsers...");
        return _context.Users;
    }
    
    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return NotFound();
        
        return Ok(user);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] User user)
    {
        Console.WriteLine("Posting user..");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != user.Id)
            return BadRequest();

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (user == null)
            return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(u => u.Id == id);
    }
}