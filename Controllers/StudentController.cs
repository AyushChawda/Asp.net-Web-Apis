using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Web_APIS.Models;
using System.Collections.Generic;
using Web_APIS.Models.DOTs;


namespace Web_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult <IEnumerable<StudentDTOs>> getStudentName()
        {
            var students = new List<StudentDTOs>();
            foreach(var item in StudentRepository.Students)
            {
                StudentDTOs obj = new StudentDTOs()
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
        //[Route("${id}", Name = "getStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<StudentDTOs> getStudentById(int id)
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

            StudentDTOs obj = new StudentDTOs()
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

            StudentDTOs obj = new StudentDTOs()
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


        // Create the post Api and add the data using the model 

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<StudentDTOs> AddStudent([FromBody]StudentModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            StudentModel student = new StudentModel()
            {
                id = model.id,
                name = model.name,
                standrad=model.standrad,
                age=model.age
                
            };
            StudentRepository.Students.Add(student);
            
            // Using Created At Route

            return CreatedAtRoute("getStudentById", new { id = model.id }, model);
        }

        // Post Apis
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult UpdateStudent([FromBody] StudentModel model)
        {
            if (model == null || model.id <= 0)
            {
                return BadRequest();
            }

            var existingStudent = StudentRepository.Students.Where(x => x.id == model.id).FirstOrDefault();

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.name = model.name;
            existingStudent.standrad = model.standrad;
            existingStudent.age = model.age;

            return Ok();
        }

    }
}
