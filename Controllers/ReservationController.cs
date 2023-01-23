using cinema_warmup_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cinema_warmup_app.Controllers;

[Produces("application/json")]
[Route("api/Reservations")]
public class ReservationController : Controller
{
    private readonly CinemadbContext _context;

    public ReservationController(CinemadbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IEnumerable<Reservation> GetReservation()
    {
        Console.WriteLine("Getting reservations...");
        return _context.Reservations;
    }
    
    // GET ALL FOR SINGLE MOVIE SHOWING
    [HttpGet("ForMovieShowing/{idMovieShowing}")]
    public IEnumerable<Reservation> GetReservations([FromRoute] int idMovieShowing)
    {
        Console.WriteLine($"Getting reservations for single movie showing... ({idMovieShowing})");

        IEnumerable<Reservation> result = _context.Reservations.Where(r => r.Id == idMovieShowing);

        return result;
    }

    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<Reservation>> GetReservation([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reservation = await _context.Reservations.SingleOrDefaultAsync(r => r.Id == id);

        if (reservation == null)
            return NotFound();
        
        return Ok(reservation);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> PostReservation([FromBody] Reservation reservation)
    {
        Console.WriteLine("Posting reservation..");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReservation([FromRoute] int id, [FromBody] Reservation reservation)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != reservation.Id)
            return BadRequest();

        _context.Entry(reservation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReservationExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reservation = await _context.Reservations.SingleOrDefaultAsync(r => r.Id == id);
        if (reservation == null)
            return NotFound();

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();

        return Ok(reservation);
    }

    private bool ReservationExists(int id)
    {
        return _context.Reservations.Any(u => u.Id == id);
    }
}