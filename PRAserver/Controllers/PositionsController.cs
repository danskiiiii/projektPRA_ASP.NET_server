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
    public class PositionsController : ApiController
    {
        private PRAserverContext db = new PRAserverContext();

        // GET: api/Positions
        public IQueryable<Position> GetPositions()
        {
            return db.Positions;
        }

        // GET: api/positions/pageSize/pageNumber 
        [Route("api/positions/{pageSize:int}/{pageNumber:int}")]
        public IHttpActionResult Get(int pageSize, int pageNumber)
        {
            try
            {
                if (pageSize < 1 || pageNumber < 1) return BadRequest("Error. Page indexes start at 1.");
                var totalCount = this.db.Positions.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            var items = db.Positions;                       

            var itemsSorted = items.OrderBy(o => o.PositionId).Skip((pageNumber - 1) * pageSize)
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

        // GET: api/Positions/5
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> GetPosition(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }

        // PUT: api/Positions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPosition(int id, Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != position.PositionId)
            {
                return BadRequest();
            }

            db.Entry(position).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(id))
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

        // POST: api/Positions
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> PostPosition(Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Positions.Add(position);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = position.PositionId }, position);
        }

        // DELETE: api/Positions/5
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> DeletePosition(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            db.Positions.Remove(position);
            await db.SaveChangesAsync();

            return Ok(position);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PositionExists(int id)
        {
            return db.Positions.Count(e => e.PositionId == id) > 0;
        }
    }
}