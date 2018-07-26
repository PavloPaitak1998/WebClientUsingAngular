using DataAccessLayer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public sealed class Departure: IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public int FlightNumber { get; set; }
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        [ForeignKey("Crew")]
        public int CrewId { get; set; }
        public Crew Crew { get; set; }

        [ForeignKey("Plane")]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
    }
}
