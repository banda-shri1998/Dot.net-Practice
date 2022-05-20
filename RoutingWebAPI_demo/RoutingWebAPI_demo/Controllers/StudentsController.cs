using RoutingWebAPI_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoutingWebAPI_demo.Controllers
{
    [RoutePrefix("Students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>() {
            new Student(){ id=1,name="Shri" },
            new Student(){ id=2,name="Shrikant" },
            new Student(){ id=3,name="Shrinath" },
            new Student(){ id=4,name="Shritej" },
            new Student(){ id=5,name="Shrinivas" },
        };

        public List<string> CourseList { get; set; }
        [HttpGet]
        [Route]
        public IEnumerable<Student> GetAllStudents() {
            return students;
        }
        [Route("{Stuid}/{id}")]
        public IEnumerable<Student> GetStudentByIDs(int Stuid,int id) 
        {
            List<Student> stu = new List<Student>();
            stu.Add( students.FirstOrDefault(x => x.id == Stuid));
            stu.Add(students.FirstOrDefault(x => x.id == id));
            return stu;
        }
        [Route("{id}/Courses")]
        public IEnumerable<string> GetCourseList(int id) {
            if (id == 1) {
                CourseList = new List<string>() { "maths", "Science", "History" };
            }
            else if (id == 2)
            {
                CourseList = new List<string>() { "stats", "Account", "Biology" };
            }
            else if (id == 3)
            {
                CourseList = new List<string>() { "C", "java", "python" };
            }
            else if (id == 4) {
                CourseList = new List<string>() { "c#", "ASP.Net", "MVC" };
            }
            else
            {
                CourseList = new List<string>() { "Geometry", "English", "Hindi" };
            }
            return CourseList;
        }
        [Route("{id}")]
        public Student GetStudentInfo(int id = 1) {
            return students.FirstOrDefault(s => s.id == id);
        }
    }
}
