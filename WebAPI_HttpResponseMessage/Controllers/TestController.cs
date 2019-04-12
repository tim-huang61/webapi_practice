using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI_HttpResponseMessage.Models;

namespace WebAPI_HttpResponseMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET
        public HttpResponseMessage Get()
        {
            var student = new Student();
            student.Name = "Tim";
            var httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(student));
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            return httpResponseMessage;
        }
    }
}