using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public Status Status { get; set; }
        public Address Address { get; set; } = new Address();
        public int AddressId { get; set; }
    }

    public enum Status
    {
        active = 0,
        inactive = 1,
        blocked = 2
    }
}
