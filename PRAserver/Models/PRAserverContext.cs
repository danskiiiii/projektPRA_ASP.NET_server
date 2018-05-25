using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRAserver.Models
{
    public class PRAserverContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PRAserverContext() : base("name=PRAserverContext")
        {
        }

        public System.Data.Entity.DbSet<PRAserver.Models.FilmCrew> FilmCrews { get; set; }

        public System.Data.Entity.DbSet<PRAserver.Models.Position> Positions { get; set; }

        public System.Data.Entity.DbSet<PRAserver.Models.Contract> Contracts { get; set; }

        public System.Data.Entity.DbSet<PRAserver.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<PRAserver.Models.Studio> Studios { get; set; }
    }
}
