using cinema_warmup_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cinema_warmup_app.Controllers;

[Produces("application/json")]
[Route("api/Seats")]
public class SeatController : Controller
{
    private readonly CinemadbContext _context;

    public SeatController(CinemadbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IEnumerable<Seat> GetSeats()
    {
        Console.WriteLine("GettingSeat...");
        return _context.Seats;
    }
    
    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<Seat>> GetSeat([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var seat = await _context.Seats.SingleOrDefaultAsync(s => s.Id == id);

        if (seat == null)
            return NotFound();
        
        return Ok(seat);
    }
    
    // GET ALL FROM SINGLE CINEMA HALL
    [HttpGet("ForCinemaHall/{idCinemaHall}")]
    public IEnumerable<Seat> GetMovieShowings([FromRoute] int idCinemaHall)
    {
        Console.WriteLine($"Getting Seats from cinema hall... ({idCinemaHall})");

        IEnumerable<Seat> result = _context.Seats.Where(s => s.IdCinemaHall == idCinemaHall);

        return result;
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> PostSeat([FromBody] Seat seat)
    {
        Console.WriteLine("Posting seat..");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Seats.Add(seat);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSeat", new { id = seat.Id }, seat);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSeat([FromRoute] int id, [FromBody] Seat seat)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != seat.Id)
            return BadRequest();

        _context.Entry(seat).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SeatExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeat([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var seat = await _context.Seats.SingleOrDefaultAsync(u => u.Id == id);
        if (seat == null)
            return NotFound();

        _context.Seats.Remove(seat);
        await _context.SaveChangesAsync();

        return Ok(seat);
    }

    private bool SeatExists(int id)
    {
        return _context.Seats.Any(s => s.Id == id);
    }
}