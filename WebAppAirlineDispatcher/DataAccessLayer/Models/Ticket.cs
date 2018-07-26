using DataAccessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public sealed class Ticket : IEntity
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public int FlightNumber { get; set; }

        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
