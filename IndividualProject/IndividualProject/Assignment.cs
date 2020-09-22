using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Assignment
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public string OralMark { get; set; }
        public string TotalMark { get; set; }
        public List<Student> StudentsList { get; set; }

        public Assignment() { }
        public Assignment(string title, DateTime dateTime)
        {
            Title = title;
            SubDateTime = dateTime;
            StudentsList = new List<Student>();
        }

        public void AssignStudent(Student student)
        {
            StudentsList.Add(student);
        }
    }
}
