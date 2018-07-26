using DataAccessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public sealed class PlaneType : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public double Carrying { get; set; }

        public Plane Plane { get; set; }
    }
}
