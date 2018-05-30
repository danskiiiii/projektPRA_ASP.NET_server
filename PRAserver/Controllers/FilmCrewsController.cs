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
    public class FilmCrewsController : ApiController
    {
        private PRAserverContext db = new PRAserverContext();

        // GET: api/FilmCrews
        public IQueryable<FilmCrew> GetFilmCrews()
        {
            return db.FilmCrews;
        }

        // GET: api/filmcrews/pageSize/pageNumber 
        [Route("api/filmcrews/{pageSize:int}/{pageNumber:int}")]
        public IHttpActionResult Get(int pageSize, int pageNumber)
        {
            var totalCount = this.db.FilmCrews.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var items = from b in db.FilmCrews
                        select new FilmCrewDetailDTO()
                        {
                            CrewMemberId=b.CrewMemberId,
                            Name=b.Name,
                            Firstname=b.Firstname,
                            Age=b.Age,
                            Position=b.Position.PositionName                            
                        };

            var itemsSorted = items.OrderBy(o => o.CrewMemberId).Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            ///////////  NOTE TO SELF: leftovers from snippet that I used here 
            /////////// (returns more data)
            //var result = new                          
            //{
            //    TotalCount = totalCount,
            //    TotalPages = totalPages,
            //    Books = booksSorted  
            //};
            return Ok(itemsSorted);
        }



        // GET: api/FilmCrews/5
        [ResponseType(typeof(FilmCrew))]
        public async Task<IHttpActionResult> GetFilmCrew(int id)
        {
            FilmCrew filmCrew = await db.FilmCrews.FindAsync(id);
            if (filmCrew == null)
            {
                return NotFound();
            }

            return Ok(filmCrew);
        }

        // PUT: api/FilmCrews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFilmCrew(int id, FilmCrew filmCrew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filmCrew.CrewMemberId)
            {
                return BadRequest();
            }

            db.Entry(filmCrew).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmCrewExists(id))
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

        // POST: api/FilmCrews
        [ResponseType(typeof(FilmCrew))]
        public async Task<IHttpActionResult> PostFilmCrew(FilmCrew filmCrew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FilmCrews.Add(filmCrew);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = filmCrew.CrewMemberId }, filmCrew);
        }

        // DELETE: api/FilmCrews/5
        [ResponseType(typeof(FilmCrew))]
        public async Task<IHttpActionResult> DeleteFilmCrew(int id)
        {
            FilmCrew filmCrew = await db.FilmCrews.FindAsync(id);
            if (filmCrew == null)
            {
                return NotFound();
            }

            db.FilmCrews.Remove(filmCrew);
            await db.SaveChangesAsync();

            return Ok(filmCrew);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmCrewExists(int id)
        {
            return db.FilmCrews.Count(e => e.CrewMemberId == id) > 0;
        }
    }
}