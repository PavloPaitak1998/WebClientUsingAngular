using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public sealed class Crew: IEntity
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty(PropertyName ="pilot")]
        public ICollection<Pilot> Pilots { get; set; }

        [JsonProperty(PropertyName = "stewardess")]
        public ICollection<Stewardess> Stewardesses { get; set; }

        public Departure Departure { get; set; }
    }
}
