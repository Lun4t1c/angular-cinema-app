using System.Diagnostics.CodeAnalysis;
using cinema_warmup_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cinema_warmup_app.Controllers;

[Produces("application/json")]
[Route("api/MovieShowings")]
public class MovieShowingController : Controller
{
    private readonly CinemadbContext _context;

    public MovieShowingController(CinemadbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IEnumerable<MovieShowing> GetMovieShowings()
    {
        Console.WriteLine("GettingMovieShowings...");

        IEnumerable<MovieShowing> result = _context.MovieShowings;

        return result;
    }
    
    // GET ALL FOR SINGLE MOVIE
    [HttpGet("ForMovie/{idMovie}")]
    public IEnumerable<MovieShowing> GetMovieShowings([FromRoute] int idMovie)
    {
        Console.WriteLine("GettingMovieShowings...");

        IEnumerable<MovieShowing> result = _context.MovieShowings.Where(ms => ms.IdMovie == idMovie);

        return result;
    }
    
    // CHECK IF SEAT IS TAKEN IN SPECIFIED MOVIE SHOWING
    [HttpGet("CheckSeat/{idSeat}/{idMovieShowing}")]
    public bool CheckIfSeatTakenInMovieShowing([FromRoute] int idSeat, [FromRoute] int idMovieShowing)
    {
        bool result = true;
        Console.WriteLine($"Checking if seat is taken in movie showing... seat({idSeat}) movieShowing({idMovieShowing})");

        MovieShowing? movieShowing = _context.MovieShowings.FirstOrDefault(showing => showing.Id == idMovieShowing);
        
        if (movieShowing == null) return false;
        
        //return movieShowing.Reservations.Any(reservation => reservation.Seats.Any(seat => seat.Id == idSeat));
        return movieShowing.Reservations.Any(reservation => reservation.SeatsId.Any(seatId => seatId == idSeat));
    }

    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieShowing>> GetMovieShowing([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var movieShowing = await _context.MovieShowings.SingleOrDefaultAsync(ms => ms.Id == id);

        if (movieShowing == null)
            return NotFound();
        
        return Ok(movieShowing);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> PostMovieShowing([FromBody] MovieShowing movieShowing)
    {
        Console.WriteLine("Posting MovieShowing..");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        movieShowing.IdCinemaHall = movieShowing.CinemaHall.Id;
        movieShowing.CinemaHall = null;

        _context.MovieShowings.Add(movieShowing);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMovieShowing", new { id = movieShowing.Id }, movieShowing);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMovieShowing([FromRoute] int id, [FromBody] MovieShowing movieShowing)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != movieShowing.Id)
            return BadRequest();

        _context.Entry(movieShowing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieShowingExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovieShowing([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var movieShowing = await _context.MovieShowings.SingleOrDefaultAsync(u => u.Id == id);
        if (movieShowing == null)
            return NotFound();

        _context.MovieShowings.Remove(movieShowing);
        await _context.SaveChangesAsync();

        return Ok(movieShowing);
    }

    private bool MovieShowingExists(int id)
    {
        return _context.MovieShowings.Any(ms => ms.Id == id);
    }
}