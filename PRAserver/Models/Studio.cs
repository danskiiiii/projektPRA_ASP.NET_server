using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRAserver.Models
{
    public class Studio
    {
        [Key]
        public int StudioId { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearOfEstablishment { get; set; }

    }
}