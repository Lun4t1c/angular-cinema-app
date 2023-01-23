using System.Net;
using System.Text.Json;
using cinema_warmup_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cinema_warmup_app.Controllers;

[Produces("application/json")]
[Route(@"api/Movies")]
public class MovieController : Controller
{
    readonly string MoviesURL = @"http://localhost:3000/movies";
    private readonly CinemadbContext _context;

    public MovieController(CinemadbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MoviesURL);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using(Stream stream = response.GetResponseStream())
        using(StreamReader reader = new StreamReader(stream))
        {
            string s = reader.ReadToEnd();
            var movies = JsonSerializer.Deserialize<IList<Movie>>(s);
            return movies;
        }
    }
    
    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie([FromRoute] int id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MoviesURL + '/' + id);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using(Stream stream = response.GetResponseStream())
        using(StreamReader reader = new StreamReader(stream))
        {
            string s = reader.ReadToEnd();
            var movies = JsonSerializer.Deserialize<Movie>(s);
            return movies;
        }
    }
}