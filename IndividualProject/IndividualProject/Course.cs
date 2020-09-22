using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Course
    {
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Trainer> TrainersList { get; set; }
        public List<Student> StudentsList { get; set; }
        public List<Assignment> AssignmentsList { get; set; }
        public List<Course> CourseList { get; set; }
        public int Id { get; set; }
        public List<int> studentpercourseList = new List<int>();

        public Course() { }
        public Course(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Course(string title, string type)
        {
            int id = Id; 
            Title = title;
            Type = type;
            CourseList = new List<Course>();
            TrainersList = new List<Trainer>();
            StudentsList = new List<Student>();
            AssignmentsList = new List<Assignment>();
        }
        
        public void SetStudent(Student student)
        {
            StudentsList.Add(student);
        }

        public void SetTrainer(Trainer trainer)
        {
            TrainersList.Add(trainer);
        }

        public void SetAssignment(string title, DateTime dateTime)
        {
            AssignmentsList.Add(new Assignment(title, dateTime));
        }

        public void AssgnmentToStudent(string assignTitle, string studFirstName, string studLastName)
        {
            foreach(Student student in StudentsList)
            {
                if(student.FirstName == studFirstName && student.LastName == studLastName)
                {
                    foreach(Assignment assignment in AssignmentsList)
                    {
                        if(assignment.Title == assignTitle)
                        {
                            assignment.AssignStudent(student);
                        }
                    }
                }
            }
        }
    }
}
