namespace SQLConnector
{
    public class Address
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
