using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzykladApiWyklad.Models;
using System.Collections.Generic;
using System;
using PrzykladApiWyklad.Services;
using System.Reflection;

namespace PrzykladApiWyklad.Controllers
{

    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMyServices _MyServices;


        public StudentsController(IMyServices MyServices)
        {
            _MyServices = MyServices;
        }

        //Convention over configuration
        [HttpGet]
        public IActionResult GetStudents() // action metoda
        {
            return Ok(_MyServices.GetStudents());
        }

        [HttpGet("{nrIndex}")]
        // http://..... / students/{nrIndex}
        public IActionResult GetStudent(string nrIndex)
        {
            if (_MyServices.GetStudents().Exists(e => e.IndexNumber == nrIndex))
                return Ok(_MyServices.GetStudents().Find(e => e.IndexNumber == nrIndex));
            else
                return NotFound("Student with id: " + nrIndex + " not found");

        }


        [HttpPost]
        public IActionResult AddStudents(Student student)
        {

            if (student != null && !(_MyServices.GetStudents().Exists(e => e.IndexNumber == student.IndexNumber)))
            {
                _MyServices.AddStudent(student);
                return Ok("Added new student with id: " + student.IndexNumber);
            }
            else return BadRequest("Invalid input, please try one more time");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            if (_MyServices.GetStudents().Exists(e => e.IndexNumber == id) && id != null)
            {
                _MyServices.DeleteStudent(id);
                return Ok("Student " + id + " deleted");
            }
            else return NotFound("Student with id: " + id + " not found");


        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Student student, String id)
        {
            foreach (PropertyInfo prop in student.GetType().GetProperties())
            {
                if (prop.GetValue(student) == null)
                {
                    return BadRequest("Wrong inputs");
                }

            }

            if (_MyServices.GetStudents().Exists(e => e.IndexNumber == id))
            {
                _MyServices.UpdateStudent(student, id);
                return Ok("Updated student");
            }
            else
                return NotFound("Student with id: " + id + " not found");
        }




    }
}
