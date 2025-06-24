using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public List<string> get()
        {
            return new List<string>() { "Ayush" ,"Vaibhav", "Raghav" };
        }
    }
}
