using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLConnectorExtra;
using System;

namespace SQLConnector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.Include(u => u.Address).ToList();
            var userResponseModels = _mapper.Map<List<UserResponseModel>>(users);

            return Ok(userResponseModels);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateUserDto userDto)
{
            var address = _context.Address
          .FirstOrDefault(a => a.City == userDto.City && a.Region == userDto.Region);
            if (address == null)
            {
                address = new Address
                {
                    City = userDto.City,
                    Region = userDto.Region
                };
                _context.Address.Add(address);
            }

            // Create the user
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Status = userDto.Status,
                Address = address
            };

            // Add user to the context
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
        }
    }    
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
