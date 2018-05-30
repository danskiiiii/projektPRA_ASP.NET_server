using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRAserver.Models
{
    /// <summary>
    /// Model class for sending total count of each item in the database
    /// </summary>
    public class Stats
    {
        public int  MoviesCount    { get; set; }
        public int  ContractsCount { get; set; }
        public int  FilmCrewsCount { get; set; }
        public int  PositionsCount { get; set; }
        public int  StudiosCount   { get; set; }
    }
}