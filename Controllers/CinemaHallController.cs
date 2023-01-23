using cinema_warmup_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cinema_warmup_app.Controllers;

[Produces("application/json")]
[Route("api/CinemaHalls")]
public class CinemaHallController : Controller
{
    private readonly CinemadbContext _context;

    public CinemaHallController(CinemadbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IEnumerable<CinemaHall> GetCinemaHalls()
    {
        Console.WriteLine("Getting cinema halls...");
        return _context.CinemaHalls;
    }
    
    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<CinemaHall>> GetCinemaHall([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cinemaHall = await _context.CinemaHalls.SingleOrDefaultAsync(ch => ch.Id == id);

        if (cinemaHall == null)
            return NotFound();
        
        return Ok(cinemaHall);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> PostCinemaHall([FromBody] CinemaHall cinemaHall)
    {
        Console.WriteLine("Posting CinemaHall..");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.CinemaHalls.Add(cinemaHall);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCinemaHall", new { id = cinemaHall.Id }, cinemaHall);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PuCinemaHall([FromRoute] int id, [FromBody] CinemaHall cinemaHall)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != cinemaHall.Id)
            return BadRequest();

        _context.Entry(cinemaHall).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CinemaHallExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinemaHall([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cinemaHall = await _context.CinemaHalls.SingleOrDefaultAsync(ch => ch.Id == id);
        if (cinemaHall == null)
            return NotFound();

        _context.CinemaHalls.Remove(cinemaHall);
        await _context.SaveChangesAsync();

        return Ok(cinemaHall);
    }

    private bool CinemaHallExists(int id)
    {
        return _context.CinemaHalls.Any(u => u.Id == id);
    }
}