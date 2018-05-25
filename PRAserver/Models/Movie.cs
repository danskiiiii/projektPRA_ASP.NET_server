using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRAserver.Models
{
    public class Movie
    {
        [Key]
        public int  MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        public int ProductionYear { get; set; }
        public decimal Budget { get; set; }
        public string Genre { get; set; }

        [ForeignKey("Studio")]
        public int StudioId { get; set; }
        [JsonIgnore]
        public virtual Studio Studio { get; set; }

    }
}