using DataAccessLayer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public sealed class Plane : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [NotMapped]
        public TimeSpan Lifetime { get; set; }

        public long LifetimeTicks
        {
            get
            {
                return Lifetime.Ticks;
            }
            set
            {
                Lifetime = TimeSpan.FromTicks(value);
            }
        }

        [ForeignKey("PlaneType")]
        public int PlaneTypeId { get; set; }
        public PlaneType PlaneType { get; set; }

        public Departure Departure { get; set; }
    }
}
