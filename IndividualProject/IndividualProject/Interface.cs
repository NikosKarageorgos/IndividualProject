
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Interface
    {
        public Data Database;
        public bool IsInitialized;

        public Interface(Data database)
        {
            Database = database;
        }

        public void Initialize()
        {
            if (IsInitialized)
                Log("Interface is already running");

            IsInitialized = true;
            Init();
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public string AwaitInput(string message)
        {
            Log(message);
            return Console.ReadLine();
        }

        public bool YNPrompt(string message)
        {
            string[] yesAnswers = { "Y", "y", "YES", "Yes", "yes", "" };
            string[] noAnswers = { "N", "n", "NO", "No", "no" };

            string input = AwaitInput(message + " Y/N?: ");

            if (Array.Exists(yesAnswers, element => element == input))
                return true;

            if (Array.Exists(noAnswers, element => element == input))
                return false;

            Log("Invalid answer. Please answer with Yes or No");
            return YNPrompt(message);
        }

        public int OptionsPrompt(string[] options)
        {
            List<int> availableOptions = new List<int>();
            Log("What would you like to do?");

            // Print options
            for (int i = 0; i < options.Length; i++)
            {
                availableOptions.Add(i);
                Log(i + " - " + options[i]);
            }

            string input = AwaitInput("Please type the number of the option you wish to choose: ");

            // Validate input
            try
            {
                int choice = int.Parse(input);
                if (availableOptions.Exists(option => option == choice))
                    return choice;
                else
                    Log("The option you chose is invalid");
            }
            catch (Exception e)
            {
                Log("Only numbers are allowed");
            }

            return OptionsPrompt(options);
        }

        public void ListData(List<string> data)
        {
            Log("\n>>>>>>>>>>>>>>>>>>>>>");

            foreach (string datum in data)
                Log(datum);

            Log(">>>>>>>>>>>>>>>>>>>>>\n");
        }

        public void Init()
        {
            Log("Welcome");

            AskForDataOrGenerate();
            ShowMainMenu();
        }

        public void AskForDataOrGenerate()
        {
            if (YNPrompt("Do you wish to auto-generate data?"))
                Database.AutoDataGenerate();
            else
                EnterManualData();
        }

        public void EnterManualData()
        {
            Log("manually entering data");
            Database.CreateData();
        }


        public void ShowMainMenu()
        {
            string[] options =
            {
                "Enter data",
                "List all students",
                "List all trainers",
                "List all assignments",
                "List all courses",
                "List all the students per course",
                "List all the trainers per course",
                "List all the assignments per course",
                "List students that belong to more than one course",
                "List of students with assignments due this week",
                "Exit"
            };

            switch (OptionsPrompt(options))
            {
                case 0:
                    EnterManualData();
                    break;

                case 1:
                    Log("Listing all students");
                    ListData(Database.GetListAllStudents());
                    break;

                case 2:
                    Log("Listing all trainers");
                    ListData(Database.GetListAllTrainers());
                    break;

                case 3:
                    Log("Listing all assignments");
                    ListData(Database.GetListAllAssignments());
                    break;

                case 4:
                    Log("Listing all courses");
                    ListData(Database.GetListAllCourses());
                    break;

                case 5:
                    Log("Listing all students per course");
                    ListData(Database.GetListAllStudentsPerCourse());
                    break;

                case 6:
                    Log("Listing all trainers per course");
                    ListData(Database.GetListAllTrainersPerCourse());
                    break;

                case 7:
                    Log("Listing all assignments per course");
                    ListData(Database.GetListAllAssignmentsPerCourse());
                    break;

                case 8:
                    Log("Listing all students that belong to more than one course");
                    ListData(Database.GetListAllStudentsThatBelongToMoreThanOneCourse());
                    break;

                case 9:
                    DateTime date = new DateTime(2020, 4, 20);
                    Log("Listing all students with assignments that are due in the week of " + date.ToString("dd/MM/yyyy"));
                    ListData(Database.ListAllStudentAssignmentsDueInWeek(date));
                    break;
                case 10:
                    Environment.Exit(0);
                    break;
                default:
                    Log("No existing option selected");
                    break;
            }

            ShowMainMenu();
        }
    }
}
