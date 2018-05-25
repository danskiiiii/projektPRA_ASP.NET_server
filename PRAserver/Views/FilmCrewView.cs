using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRAserver.Views
{
    public class FilmCrewView
    {
        public int CrewMemberId { get; set; }
        
        public string Name { get; set; }
        public string Firstname { get; set; }
        public int Age { get; set; }     
        public string Position { get; set; }
    }
}