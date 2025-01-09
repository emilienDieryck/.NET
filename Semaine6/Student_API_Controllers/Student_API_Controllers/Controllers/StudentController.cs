using Microsoft.AspNetCore.Mvc;
using Student_API_Controllers.Models;

namespace Student_API_Controllers.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", Birthdate = new DateTime(1950, 12, 1) },
            new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", Birthdate = new DateTime(1970, 12, 1) },
            new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", Birthdate = new DateTime(1980, 12, 1) }
        };

        [HttpGet]
        public IList<Student> GetStudents()
        {
            return _students;
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public void addStudent(Student student)
        {
            bool isExists = _students.Any(s => s.Id == student.Id);
            if (isExists)
            {
                throw new Exception("Student already exist");
            }
            _students.Add(student);
        }

    }
}
