using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VanCityFood.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [Key, Column("RestId")]
        public int Id { get; set; }

        [Column("RestName")]
        public string Name { get; set; }

        [Column("RestType")]
        public string Type { get; set; }

        public Restaurant() { }
        public Restaurant(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }   
    }
}
