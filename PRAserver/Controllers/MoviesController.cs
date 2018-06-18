using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PRAserver.Models;
using PRAserver.ModelsDTOs;

namespace PRAserver.Controllers
{
    public class MoviesController : ApiController
    {
        private PRAserverContext db = new PRAserverContext();     


        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/movies/pageSize/pageNumber 
        [Route("api/movies/{pageSize:int}/{pageNumber:int}")]
        public IHttpActionResult Get(int pageSize, int pageNumber)
        {
            try
            {
                if (pageSize < 1 || pageNumber < 1) return BadRequest("Error. Page indexes start at 1.");

                var totalCount = this.db.Movies.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var items = from b in db.Movies
                        select new MovieDetailDTO()
                        {
                            MovieId = b.MovieId,
                            Title = b.Title,
                            ProductionYear = b.ProductionYear,
                            Budget = b.Budget,
                            Genre = b.Genre,
                            StudioName= b.Studio.Name

                        };

            var itemsSorted = items.OrderBy(o => o.MovieId).Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            if (itemsSorted.Count == 0) { throw new Exception("Query out of bounds. Empty result."); }

                return Ok(itemsSorted);
            }
            catch (Exception exc)
            {
                return BadRequest("Error. " + exc.Message);
            }
        }


        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.MovieId == id) > 0;
        }
    }
}