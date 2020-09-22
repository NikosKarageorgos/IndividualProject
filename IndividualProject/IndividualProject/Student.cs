using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Student
    {
        public List<int> coursePerStudentList = new List<int>();
        public int studentID;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TuitionFees { get; set; }

        public Student() { }
        public Student(string name, string surname)
        {
            FirstName = name;
            LastName = surname;
        }
    }
}
