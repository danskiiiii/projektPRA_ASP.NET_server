using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRAserver.Models
{
    public class FilmCrew
    {
        [Key]
        public int CrewMemberId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Firstname { get; set; }
        public int Age { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }

    }
}