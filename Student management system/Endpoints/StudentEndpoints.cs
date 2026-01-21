using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Endpoints
{
    public static class StudentEndpoints
    {
        public static void MapStudentEndpoints(this WebApplication app)
        {
            var studentService = new StudentService();

            app.MapGet("/api/students", async (HttpContext context) =>
            {
                var students = studentService.GetAllStudents();
                await context.Response.WriteAsJsonAsync(students);
            });

            app.MapGet("/api/students/{id}", async (HttpContext context, int id) =>
            {
                var student = studentService.GetStudentById(id);
                if (student == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Student not found.");
                }
                else
                {
                    await context.Response.WriteAsJsonAsync(student);
                }
            });

            app.MapPost("/api/students", async (HttpContext context) =>
            {
                var student = await context.Request.ReadFromJsonAsync<Student>();
                if (student == null)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid student data.");
                    return;
                }
                studentService.AddStudent(student);
                context.Response.StatusCode = StatusCodes.Status201Created;
                await context.Response.WriteAsJsonAsync(student);
            });

            app.MapPut("/api/students/{id}", async (HttpContext context, int id) =>
            {
                var updatedStudent = await context.Request.ReadFromJsonAsync<Student>();
                if (updatedStudent == null)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid student data.");
                    return;
                }
                var result = studentService.UpdateStudent(id, updatedStudent);
                if (!result)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Student not found.");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status204NoContent;
                }
            });

            app.MapDelete("/api/students/{id}", async (HttpContext context, int id) =>
            {
                var result = studentService.DeleteStudent(id);
                if (!result)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Student not found.");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status204NoContent;
                }
            });
        }
    }

    // Dummy StudentService and Student classes for demonstration
    public class StudentService
    {
        private static List<Student> students = new List<Student>();
        private static int nextId = 1;

        public List<Student> GetAllStudents() => students;
        public Student GetStudentById(int id) => students.FirstOrDefault(s => s.Id == id);
        public void AddStudent(Student student)
        {
            student.Id = nextId++;
            students.Add(student);
        }
        public bool UpdateStudent(int id, Student updatedStudent)
        {
            var student = GetStudentById(id);
            if (student == null) return false;
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            return true;
        }
        public bool DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student == null) return false;
            students.Remove(student);
            return true;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
