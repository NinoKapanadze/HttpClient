namespace RefitTest
{
    public class UserResponseModel
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public Status Status { get; set; }
        public AddressResponseModel Address { get; set; }
        public int AddressId { get; set; }

    }
    public class AddressResponseModel
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
    }
    public enum Status
    {
        active = 0,
        inactive = 1,
        blocked = 2
    }


}
