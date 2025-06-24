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
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult <IEnumerable<StudentModel>> getStudentName()
        {

            return Ok(StudentRepository.Students);
        }

        [HttpGet("{id}")]


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<StudentModel> getStudentById(int id)
        {
            var student = StudentRepository.Students.Where(x => x.id == id).FirstOrDefault();
            if (id<=0)
            {
                return BadRequest();
            }
            if (student == null)
            {
                return NotFound($"The id is not valid please enter the correct one");
            }

            return Ok(student);
        }

        [HttpGet("{name:alpha}")]

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<StudentModel> getStudentByName(string name)
        {
            var student = StudentRepository.Students.Where(x => x.name == name).FirstOrDefault();

            if (student == null)
            {
                return NotFound($"The name is not valid please enter the correct one");
            }

            return student;
        }

        [HttpDelete("{id}")]

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Students.Where(x => x.id == id).FirstOrDefault();
            if (student == null)
            {
                
                return NotFound();
            }

            StudentRepository.Students.Remove(student);
            return Ok();
        }
    }
}
