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
        public ActionResult <IEnumerable<StudentDOTs>> getStudentName()
        {
            var students = new List<StudentDOTs>();
            foreach(var item in StudentRepository.Students)
            {
                StudentDOTs obj = new StudentDOTs()
                {
                    id = item.id,
                    name=item.name,
                    standrad=item.standrad
                };
                students.Add(obj);
            }

            return Ok(students);
        }

        [HttpGet("{id}")]


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<StudentDOTs> getStudentById(int id)
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

            StudentDOTs obj = new StudentDOTs()
            {
                id = student.id,
                name = student.name,
                standrad = student.standrad
            };

            return Ok(obj);
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

            StudentDOTs obj = new StudentDOTs()
            {
                id = student.id,
                name = student.name,
                standrad = student.standrad
            };

            return Ok(obj);
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
                
                return NotFound($"The id is not valid please enter the correct one");
            }

            StudentRepository.Students.Remove(student);
            return Ok();
        }
    }
}
