using Microsoft.AspNetCore.Mvc;
using Web_APIS.Models;

namespace Web_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<StudentModel> getStudentName()
        {

            return StudentRepository.Students;
        }

        [HttpGet("{id}")]
        public StudentModel getStudentById(int id)
        {

            return StudentRepository.Students.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
