using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Data
    {
        public List<Course> Courses;
        public List<Student> Students;
        public static bool DataGenerate;

        public Data()
        {
            Courses = new List<Course>();
            Students = new List<Student>();
        }

        public void AutoDataGenerate()
        {
            if (DataGenerate)
            {
                Console.WriteLine("Data has auto generated");
            }

            DataGenerate = true;
            Courses = GenerateData();
            Console.WriteLine("Data has succesfully been generated");
        }

        public List<string> GetListAllStudents()
        {
            List<string> data = new List<string>();

            foreach (Course course in Courses)
            {
                foreach (Student student in course.StudentsList)
                {
                    data.Add(student.FirstName + " " + student.LastName);
                }
            }
            return data.Distinct().ToList();
        }

        public List<string> GetListAllTrainers()
        {
            List<string> data = new List<string>();

            foreach (Course course in Courses)
            {
                foreach (Trainer trainer in course.TrainersList)
                {
                    data.Add(trainer.FirstName + " " + trainer.LastName);
                }
            }
            return data.Distinct().ToList();
        }

        public List<string> GetListAllAssignments()
        {
            List<string> data = new List<string>();

            foreach (Course course in Courses)
            {
                foreach (Assignment assignment in course.AssignmentsList)
                {
                    data.Add(assignment.Title);
                }
            }
            return data;
        }

        public List<string> GetListAllCourses()
        {
            List<string> data = new List<string>();

            foreach (Course course in Courses)
                Console.WriteLine(course.Title);
            return data;
        }

        public List<string> GetListAllStudentsPerCourse()
        {
            List<string> data = new List<string>();

            foreach (Course course in Courses)
            {
                foreach (Student student in course.StudentsList)
                {
                    data.Add(course.Title + ": " + student.FirstName + " " + student.LastName);
                }
            }
            return data;
        }

        public List<string> GetListAllTrainersPerCourse()
        {
            List<string> data = new List<string>();

            foreach (Course course in Courses)
            {
                foreach (Trainer trainer in course.TrainersList)
                {
                    data.Add(course.Title + ": " + trainer.FirstName + " " + trainer.LastName);
                }
            }
            return data;
        }

        public List<string> GetListAllAssignmentsPerCourse()
        {
            List<string> data = new List<string>();

            foreach (Course course in Courses)
            {
                foreach (Assignment assignment in course.AssignmentsList)
                {
                    data.Add(course.Title + ": " + assignment.Title);
                }
            }
            return data;
        }

        public List<string> GetListAllStudentsThatBelongToMoreThanOneCourse()
        {
            List<string> students = GetListAllStudents();
            List<string> data = new List<string>();

            foreach (string studentName in students)
            {
                List<string> courseNames = new List<string>();

                foreach (Course course in Courses)
                {
                    foreach (Student student in course.StudentsList)
                    {
                        if (student.FirstName + " " + student.LastName == studentName)
                            courseNames.Add(course.Title);
                    }
                }
            }

            return data;
        }
        public List<string> ListAllStudentAssignmentsDueInWeek(DateTime date)
        {
            DayOfWeek day = date.DayOfWeek;
            DateTime dateFrom = date.AddDays(-((int)day - 1));
            DateTime dateTo = date.AddDays((7 - (int)day) - 2);

            List<string> students = GetListAllStudents();
            List<string> data = new List<string>();

            foreach (string studentName in students)
            {
                List<string> assignmentsDue = new List<string>();

                foreach (Course course in Courses)
                {
                    foreach (Assignment assignment in course.AssignmentsList)
                    {
                        foreach (Student student in assignment.StudentsList)
                        {
                            if (student.FirstName + " " + student.LastName == studentName
                                && (assignment.SubDateTime >= dateFrom && assignment.SubDateTime <= dateTo))
                            {
                                assignmentsDue.Add(course.Title + ": " + assignment.Title);
                            }
                        }
                    }
                }

                if (assignmentsDue.Count > 0)
                    data.Add(studentName + "(" + string.Join(", ", assignmentsDue) + ")");
            }

            return data;
        }

        public List<Course> GenerateData()
        {
            Student student1 = new Student("Nikos", "Karageorgos");
            Student student2 = new Student("Bruce", "Wayne");
            Student student3 = new Student("Scott", "Snyder");
            Student student4 = new Student("Hayao", "Miyazaki");

            Trainer trainer1 = new Trainer("Darth", "Vader");
            Trainer trainer2 = new Trainer("Yoda", "Master");
            Trainer trainer3 = new Trainer("Neil", "Peart");

            Course course1 = new Course("C#", "Part time");
            course1.SetTrainer(trainer1);
            course1.SetAssignment("Classes", new DateTime(2020, 4, 20));
            course1.SetAssignment("Loops", new DateTime(2020, 4, 18));
            course1.SetStudent(student1);
            course1.SetStudent(student2);
            course1.AssgnmentToStudent("Classes", student1.FirstName, student1.LastName);
            course1.AssgnmentToStudent("Classes", student2.FirstName, student2.LastName);
            course1.AssgnmentToStudent("Loops", student1.FirstName, student1.LastName);

            Course course2 = new Course("Java", "Part time");
            course2.SetTrainer(trainer3);
            course2.SetAssignment("Variables", new DateTime(2020, 4, 20));
            course2.SetAssignment("Classes", new DateTime(2020, 4, 17));
            course2.SetAssignment("Creativity", new DateTime(2020, 4, 16));
            course2.SetStudent(student3);
            course2.SetStudent(student2);
            course2.AssgnmentToStudent("Variables", student3.FirstName, student3.LastName);
            course2.AssgnmentToStudent("Classes", student3.FirstName, student3.LastName);
            course2.AssgnmentToStudent("Creativity", student3.FirstName, student3.LastName);
            course2.AssgnmentToStudent("Creativity", student2.FirstName, student2.LastName);

            Course course3 = new Course("Ping Pong", "Full time");
            course3.SetTrainer(trainer2);
            course3.SetAssignment("Service", new DateTime(2020, 4, 20));
            course3.SetAssignment("The Force", new DateTime(2020, 4, 19));
            course3.SetStudent(student4);
            course3.AssgnmentToStudent("Service", student4.FirstName, student4.LastName);
            course3.AssgnmentToStudent("Service", student4.FirstName, student4.LastName);

            List<Course> Data = new List<Course>();
            Data.Add(course1);
            Data.Add(course2);
            Data.Add(course3);
            return Data;
        }

       
        public void CreateData()
        {
            List<Course> CourseList = new List<Course>();
            List<Student> StudentList = new List<Student>();
            List<Trainer> TrainersList = new List<Trainer>();
            List<Assignment> AssignmentList = new List<Assignment>();


            Console.WriteLine("\nNumber of courses");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Name of course");
                string name = Console.ReadLine();
                Course course = new Course();
                CourseList.Add(course);
            }

            Console.WriteLine("\nNumber of Students");
            int b = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < b; i++)
            {
                Console.WriteLine("Write name for Student");
                string firstName = Console.ReadLine();
                Console.WriteLine("Write surname for Student");
                string lastName = Console.ReadLine();
                Console.WriteLine("Year of birth");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Month");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Day");
                int day = Convert.ToInt32(Console.ReadLine());
                Student student = new Student();
                StudentList.Add(student);
            }
            Console.WriteLine();

            Console.WriteLine("\nNumber of Trainers");
            int c = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < c; i++)
            {
                Console.WriteLine("Write name for Trainer");
                string firstName = Console.ReadLine();
                Console.WriteLine("Write surname for Trainer");
                string lastName = Console.ReadLine();
                Trainer trainer = new Trainer();
                TrainersList.Add(trainer);
            }

            Console.WriteLine("\nNumber of Assignments");
            int d = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < d; i++)
            {
                Console.WriteLine("Name of Assignment");
                string name = Console.ReadLine();
                Assignment assignment = new Assignment();
                AssignmentList.Add(assignment);
            }

            Console.WriteLine("Assign student per course");
            Console.WriteLine("select course");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"number of student for {a} course");
            int y = Convert.ToInt32(Console.ReadLine());
            CourseList[a].studentpercourseList = new List<int>();
            for (int i = 0; i < y; i++)
            {
                Console.WriteLine("Student ID");
                int s = Convert.ToInt32(Console.ReadLine());
                CourseList[a].studentpercourseList.Add(s);
            }

            //show results Student Per course
            for (int i = 0; i < CourseList.Count; i++)
            {
                for (int j = 0; i < CourseList[i].studentpercourseList.Count; i++)
                {

                    int s = CourseList[i].studentpercourseList[j];
                    Student st = StudentList[s];
                    Console.WriteLine(st.FirstName,st.LastName,st.DateOfBirth);
                }
            }
        }
    }
}
