namespace SQLConnector
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public Status Status { get; set; }
        public Address Address { get; set; } 
        public int AddressId { get; set; }
    }

    public enum Status
    {
        active = 0,
        inactive = 1,
        blocked = 2
    }
}
