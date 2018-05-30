using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PRAserver.Models;

namespace PRAserver.Controllers
{
    /// <summary>
    /// Provides basic stats
    /// </summary>
    public class StatsController : ApiController
    {
        private PRAserverContext db = new PRAserverContext();



        /// <summary>
        /// Returns total count for each item in the database
        /// </summary>
        /// <returns></returns>
        // GET: api/Stats 
        [Route("api/Stats")]
        public List<int> GetStats()
        {
            List<int> itemCount = new List<int>
            {   db.Movies.Count(),
                db.Contracts.Count(),
                db.FilmCrews.Count(),
                db.Positions.Count(),
                db.Studios.Count()
            };

            return itemCount;
        }
    }
}
