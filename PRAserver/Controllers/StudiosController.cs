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

namespace PRAserver.Controllers
{
    public class StudiosController : ApiController
    {
        private PRAserverContext db = new PRAserverContext();

        // GET: api/Studios
        public IQueryable<Studio> GetStudios()
        {
            return db.Studios;
        }

        // GET: api/studios/pageSize/pageNumber 
        [Route("api/studios/{pageSize:int}/{pageNumber:int}")]
        public IHttpActionResult Get(int pageSize, int pageNumber)
        {
            var totalCount = this.db.Studios.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            var items = db.Studios;

            var itemsSorted = items.OrderBy(o => o.StudioId).Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
            return Ok(itemsSorted);
        }

        // GET: api/Studios/5
        [ResponseType(typeof(Studio))]
        public async Task<IHttpActionResult> GetStudio(int id)
        {
            Studio studio = await db.Studios.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }

            return Ok(studio);
        }

        // PUT: api/Studios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudio(int id, Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studio.StudioId)
            {
                return BadRequest();
            }

            db.Entry(studio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(id))
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

        // POST: api/Studios
        [ResponseType(typeof(Studio))]
        public async Task<IHttpActionResult> PostStudio(Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Studios.Add(studio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = studio.StudioId }, studio);
        }

        // DELETE: api/Studios/5
        [ResponseType(typeof(Studio))]
        public async Task<IHttpActionResult> DeleteStudio(int id)
        {
            Studio studio = await db.Studios.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }

            db.Studios.Remove(studio);
            await db.SaveChangesAsync();

            return Ok(studio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudioExists(int id)
        {
            return db.Studios.Count(e => e.StudioId == id) > 0;
        }
    }
}