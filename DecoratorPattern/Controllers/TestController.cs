using DecoratorPattern.TestDbContextDirectory;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {   
        [HttpGet("Test")]
        public IActionResult Get()
        {
            using var context = new TestDbContext();

            context.Users.Add(new UserEntity()
            {
                Name = "Test",
            });

            return Ok();
        }
    }
}