namespace VanCityFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
