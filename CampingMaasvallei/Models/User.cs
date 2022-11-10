using System.ComponentModel.DataAnnotations;


namespace CampingMaasvallei.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set;}
        public string last_name { get; set;}
        public string email { get; set;}
        public string country { get; set;}
        public string region { get; set;}
        public string adress { get; set;}
        public string city { get; set;}
        public string postal_code { get; set;}
        public string date_of_birth { get; set;}
}
}
