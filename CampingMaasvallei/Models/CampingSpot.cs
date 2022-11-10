using System.ComponentModel.DataAnnotations;


namespace CampingMaasvallei.Models
{
    public class CampingSpot
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public float length { get; set; }
        public float width { get; set; }
        public float area { get; set; }
        public bool booked { get; set; }
    }
}
