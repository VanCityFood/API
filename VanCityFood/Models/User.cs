using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VanCityFood.Models
{
    [Table("Users")]
    public class User
    {
        [Key, Column("UserId")]
        public int Id { get; set; }

        [Column("UserName")]
        public string Name { get; set; }

        [Column("UserEmail")]
        public string Email { get; set; }

        [Column("UserPass")]
        public string Pass { get; set; }


        public User() { }
        public User(int id, string name, string email, string pass)
        {
            Id = id;
            Name = name;
            Email = email;
            Pass = pass;
        }
        public User (string email, string pass)
        {
            Email = email;
            Pass=pass;
        }

      
    }
}
