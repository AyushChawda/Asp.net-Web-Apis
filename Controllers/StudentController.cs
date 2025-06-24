using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Web_APIS.Models;
using System.Collections.Generic;


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

        [HttpGet("{name:alpha}")]
        public StudentModel getStudentByName(string name)
        {

            return StudentRepository.Students.Where(x => x.name == name).FirstOrDefault();
        }

        [HttpDelete("{id}")]

        public bool DeleteStudent(int id)
        {
            var student = StudentRepository.Students.Where(x => x.id == id).FirstOrDefault();
            if (student!=null)
            {
                StudentRepository.Students.Remove(student);
            }
            
            return true;
        }
    }
}
