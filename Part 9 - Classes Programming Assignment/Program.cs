using System.Transactions;
using System.Xml.Serialization;

namespace Part_9___Classes_Programming_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            string choice = "", fName, lName;
            int choice2 = 0;
            List <Student> students = new List <Student>();
            Console.SetBufferSize(200, 200);
            Console.SetWindowSize(150, 40);

            students.Add(new Student("Emmett", "Cornies"));
            students.Add(new Student("Fred", "Flintstone"));
            students.Add(new Student("Lightning", "McQueen"));
            students.Add(new Student("Jack", "Sparrow"));
            students.Add(new Student("Tony", "Stark"));

            while (!done)
            {
                // Intro

                Console.SetCursorPosition(35, 2);
                Console.WriteLine("Welcome to my extremely cool menu screen for my classes programming assignment!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Pick what part of the assignment you'd like to see.");
                Console.WriteLine("Option 1: Display Students");
                Console.WriteLine("Option 2: Student Details");
                Console.WriteLine("Option 3: Add a Student");
                Console.WriteLine("Option 4: Remove a student");
                Console.WriteLine("Option 5: Search for a Student");
                Console.WriteLine("Option 6: Edit a Student");
                Console.WriteLine("Option 7: Sort Students");
                Console.WriteLine("Or, you can press 'Q' to exit the program.");
                Console.WriteLine();
                Console.Write("Pick your option (1 - 7, or 'Q'.): ");
                choice = Console.ReadLine();
                choice = choice.ToUpper().Trim();
                while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7" && choice != "Q")
                {
                    Console.Write("Invalid Input. Try again: ");
                    choice = Console.ReadLine();
                }

                // Display Students

                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Here's a list of all the students in the class:");
                    Console.WriteLine();
                    DisplayStudents(students);
                    Console.WriteLine();
                    Console.WriteLine("Press 'ENTER' to return to the main menu.");
                    Console.ReadLine();
                    Console.Clear();
                }

                // Student Details

                else if (choice == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Here's a list of all the students in the class:");
                        Console.WriteLine();
                        StudentDetails(students, choice2);
                        Console.WriteLine();
                        Console.WriteLine("Press 'Q' to return to the main menu, or press 'R' to view another student's details.");
                        Console.Write("Enter your choice here: ");
                        choice = Console.ReadLine();
                        choice = choice.ToUpper().Trim();
                        while (choice != "Q" && choice != "R")
                        {
                            Console.Write("Invalid Input. Try again: ");
                            choice = Console.ReadLine();
                            choice = choice.ToUpper().Trim();
                        }
                        if (choice == "Q")
                        {
                            break;
                        }
                        else if (choice == "R")
                        {
                            continue;
                        }
                    }
                    Console.Clear();
                }

                // Add a Student

                else if (choice == "3")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Here's a list of all the students in the class:");
                        Console.WriteLine();
                        DisplayStudents(students);
                        Console.WriteLine();
                        Console.WriteLine("Enter in the name of the student you'd like to add.");
                        Console.WriteLine();
                        Console.Write("First name: ");
                        fName = Console.ReadLine();
                        Console.Write("Last name: ");
                        lName = Console.ReadLine();
                        students.Add(new Student(fName, lName));
                        Console.WriteLine();
                        Console.WriteLine($"{students[students.Count - 1]} has been added to the class.");
                        Console.WriteLine();
                        Console.WriteLine("Press 'Q' to return to the main menu, or press 'R' to add another student to the class.");
                        Console.Write("Enter your choice here: ");
                        choice = Console.ReadLine();
                        choice = choice.ToUpper().Trim();
                        while (choice != "Q" && choice != "R")
                        {
                            Console.Write("Invalid Input. Try again: ");
                            choice = Console.ReadLine();
                            choice = choice.ToUpper().Trim();
                        }
                        if (choice == "Q")
                        {
                            break;
                        }
                        else if (choice == "R")
                        {
                            continue;
                        }
                    }
                    Console.Clear();
                }

                // Remove a Student

                else if (choice == "4")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Here's a list of all the students in the class:");
                        Console.WriteLine();
                        for (int i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine($"({i}) {students[i]}");
                        }
                        Console.WriteLine();
                        Console.Write("Enter in the corresponding number of the student who you'd like to remove: ");
                        while (!int.TryParse(Console.ReadLine(), out choice2) || choice2 >= students.Count)
                        {
                            Console.Write("Invalid Input. Try again: ");
                        }
                        Console.WriteLine();
                        Console.WriteLine($"{students[choice2]} has been removed from the class.");
                        students.RemoveAt(choice2);
                        Console.WriteLine();
                        Console.WriteLine("Press 'Q' to return to the main menu, or press 'R' to remove another student from the class.");
                        Console.Write("Enter your choice here: ");
                        choice = Console.ReadLine();
                        choice = choice.ToUpper().Trim();
                        while (choice != "Q" && choice != "R")
                        {
                            Console.Write("Invalid Input. Try again: ");
                            choice = Console.ReadLine();
                            choice = choice.ToUpper().Trim();
                        }
                        if (choice == "Q")
                        {
                            break;
                        }
                        else if (choice == "R")
                        {
                            continue;
                        }
                    }
                    Console.Clear();
                }

                // Search for a Student

                else if (choice == "5")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter in the first and last name of the student you'd like to search for.");
                        Console.WriteLine();
                        Console.Write("First name: ");
                        fName = Console.ReadLine();
                        Console.Write("Last name: ");
                        lName = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine($"Here are the closest results of your search:");
                        Console.WriteLine();
                        Search(students, fName, lName);
                        Console.WriteLine();
                        Console.WriteLine("Press 'Q' to return to the main menu, or press 'R' to add another student to the class.");
                        Console.Write("Enter your choice here: ");
                        choice = Console.ReadLine();
                        choice = choice.ToUpper().Trim();
                        while (choice != "Q" && choice != "R")
                        {
                            Console.Write("Invalid Input. Try again: ");
                            choice = Console.ReadLine();
                            choice = choice.ToUpper().Trim();
                        }
                        if (choice == "Q")
                        {
                            break;
                        }
                        else if (choice == "R")
                        {
                            continue;
                        }
                    }
                    Console.Clear();
                }

                // Edit a Student

                else if (choice == "6")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter in the number corresponding to the student you'd like to edit.");
                        Console.WriteLine();
                        for (int i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine($"({i}) {students[i]}");
                        }
                        Console.WriteLine();
                        Console.Write("Your choice: ");
                        while (!int.TryParse(Console.ReadLine(), out choice2) || choice2 >= students.Count)
                        {
                            Console.Write("Invalid Input. Try again: ");
                        }
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine($"Enter in the number corresponding to the part of {students[choice2]}'s name you'd like to edit.");
                            Console.WriteLine();
                            Console.WriteLine("(1) First Name.");
                            Console.WriteLine("(2) Last Name.");
                            Console.WriteLine();
                            Console.Write("Your choice: ");
                            choice = Console.ReadLine();
                            choice = choice.Trim();
                            while (choice != "1" && choice != "2")
                            {
                                Console.Write("Invalid Input. Try again: ");
                                choice = Console.ReadLine();
                                choice = choice.Trim();
                            }
                            if (choice == "1")
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Current first name: {students[choice2].FirstName}");
                                    Console.WriteLine();
                                    Console.Write("New first name: ");
                                    choice = Console.ReadLine();
                                    choice = choice.Trim();
                                    students[choice2].FirstName = choice;
                                    Console.WriteLine();
                                    Console.WriteLine($"First name saved. Student's new name is now {students[choice2]}");
                                    Console.WriteLine();
                                    Console.WriteLine("Press 'Q' to return to the main menu, press 'R' to edit another student from the class, or press 'E' to re-edit the current student's name.");
                                    Console.Write("Enter your choice here: ");
                                    choice = Console.ReadLine();
                                    choice = choice.ToUpper().Trim();
                                    while (choice != "Q" && choice != "R" && choice != "E")
                                    {
                                        Console.Write("Invalid Input. Try again: ");
                                        choice = Console.ReadLine();
                                        choice = choice.ToUpper().Trim();
                                    }
                                    if (choice == "Q")
                                    {
                                        break;
                                    }
                                    else if (choice == "R")
                                    {
                                        break;
                                    }
                                    else if (choice == "E")
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (choice == "2")
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Current last name: {students[choice2].LastName}");
                                    Console.WriteLine();
                                    Console.Write("New last name: ");
                                    choice = Console.ReadLine();
                                    choice = choice.Trim();
                                    students[choice2].LastName = choice;
                                    Console.WriteLine();
                                    Console.WriteLine($"Last name saved. Student's new name is now {students[choice2]}");
                                    Console.WriteLine();
                                    Console.WriteLine("Press 'Q' to return to the main menu, press 'R' to edit another student from the class, or press 'E' to re-edit the current student's name.");
                                    Console.Write("Enter your choice here: ");
                                    choice = Console.ReadLine();
                                    choice = choice.ToUpper().Trim();
                                    while (choice != "Q" && choice != "R" && choice != "E")
                                    {
                                        Console.Write("Invalid Input. Try again: ");
                                        choice = Console.ReadLine();
                                        choice = choice.ToUpper().Trim();
                                    }
                                    if (choice == "Q")
                                    {
                                        break;
                                    }
                                    else if (choice == "R")
                                    {
                                        break;
                                    }
                                    else if (choice == "E")
                                    {
                                        break;
                                    }
                                }
                            }
                            if (choice == "Q")
                            {
                                break;
                            }
                            else if (choice == "R")
                            {
                                break;
                            }
                        }
                        if (choice == "Q")
                        {
                            break;
                        }
                    }
                    Console.Clear();
                }

                // Sort

                else if (choice == "7")
                {
                    Console.Clear();
                    Console.WriteLine("Here's a list of all the students in the class sorted alphabetically: ");
                    Console.WriteLine();
                    Sort(students);
                    DisplayStudents(students);
                    Console.WriteLine();
                    Console.WriteLine("Press 'ENTER' to return to the main menu.");
                    Console.ReadLine();
                    Console.Clear();
                }

                // Quit

                else if (choice == "Q")
                {
                    done = true;
                }
            }
        }
        public static void DisplayStudents(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
        }

        public static void StudentDetails(List<Student> students, int choice)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"({i}) { students[i]}");
            }
            Console.WriteLine();
            Console.Write("Enter in the corresponding number of the student whose details you'd like to view: ");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice >= students.Count)
            {
                Console.Write("Invalid Input. Try again: ");
            }
            Console.WriteLine();
            Console.WriteLine($"First name: {students[choice].FirstName}");
            Console.WriteLine($"Last name: {students[choice].LastName}");
            Console.WriteLine($"Student number: {students[choice].StudentNumber}");
            Console.WriteLine($"Email address: {students[choice].Email}");
        }

        public static void Search(List<Student> students, string fName, string lName)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].FirstName.Contains(fName) || students[i].LastName.Contains(lName))
                {
                    Console.WriteLine(students[i]);
                }
            }
        }

        public static void Sort(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - i - 1; j++)
                {
                    if (string.Compare(students[j].FirstName, students[j + 1].FirstName) > 0)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }
    }
}
