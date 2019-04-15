using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi_Cache.Filter;
using WebApi_Cache.Models;

namespace WebApi_Cache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET
//        [ETag]
        [LastModified]
        public IActionResult Get()
        {
            return Ok(new Person
            {
                Name = "Tim",
                Age = 30
            });
        } 
    }
}