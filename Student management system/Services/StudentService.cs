using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class StudentService
    {
        private readonly List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 20 },
                new Student { Id = 2, Name = "Bob", Age = 22 }
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student? GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public Student Add(Student student)
        {
            int newId = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            student.Id = newId;
            _students.Add(student);
            return student;
        }

        public bool Update(int id, Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return false;
            existing.Name = student.Name;
            existing.Age = student.Age;
            return true;
        }

        public bool Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return false;
            _students.Remove(student);
            return true;
        }
    }
}
