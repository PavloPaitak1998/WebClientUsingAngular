using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public sealed class Pilot : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        [JsonProperty(PropertyName = "exp")]
        public int Experience { get; set; }

        [ForeignKey("Crew")]
        public int CrewId { get; set; }
        public Crew Crew { get; set; }
    }
}
