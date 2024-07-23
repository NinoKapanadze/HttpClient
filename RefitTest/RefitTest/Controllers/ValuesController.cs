using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Text.Json;

namespace RefitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                })
            };

            var usersClient = RestService.For<IUserClient>("https://localhost:7026/", settings);
            var users = await usersClient.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserDto createUserDto)
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                })
            };

            var usersClient = RestService.For<IUserClient>("https://localhost:7026/", settings);
            var users = await usersClient.Create(createUserDto);
            return Ok(users);

        }
    }
}
