using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRAserver.Models
{
    public class Contract
    {

        [Key]
        public int ContractId { get; set; }
        
        public int Duration { get; set; }
        public int Salary { get; set; }

        [ForeignKey("FilmCrew")]
        public int CrewMemberId { get; set; }
        [JsonIgnore]
        public virtual FilmCrew FilmCrew { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [JsonIgnore]
        public virtual Movie Movie { get; set; }
    }
}