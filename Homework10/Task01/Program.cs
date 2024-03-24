using System.Globalization;
using Task01.Models;

namespace Task01
{
    internal class Program
    {
        #region Task1

        /*
         Create an Academy Management app
           
           The app will have users that can log in and perform some actions. The user can choose one of the 3 roles and log in:
           
               Admin
               Trainer
              - Student ( has a current Subject, and Grades )
           
           After logging in there should be different options for different roles:
           
               Admins can add/remove Teachers, Students, and other Admins ( can't remove itself )

               Trainer can choose between seeing all students and all subjects
                  - When choosing Students, all student names should appear
                  - When chosen a name, it should print all the subjects
                   When choosing Subjects, all Subject names appear with how many students attend it next to it

               - Students are shown the name of the subject that they are listening to and a list of their grades
           
               Try and handle all scenarios with exception handling. Handle expected exceptions with special messages.
           
         */

        #endregion
        static void Main(string[] args)
        {
            Subject subjects = new Subject();
            PopulateSubject(subjects);



            //Console.WriteLine(subjects.Subjects[1]);

            List<Admin> admins = new List<Admin>();
            List<Trainer> trainers = new List<Trainer>();
            List<Student> students = new List<Student>();

            /*
            //to do: to make it reusable... DONE :)
            //List<Subject> subjectsForS1 = new List<Subject>
            //{
            //    new() { Subjects = new List<string>{subjects.Subjects[0], subjects.Subjects[3], subjects.Subjects[2], subjects.Subjects[5], subjects.Subjects[3]}}
            //};

            //Dictionary<string, int> gradesForS1 = new Dictionary<string, int>
            //{
            //    { subjects.Subjects[0], 90 },
            //    { subjects.Subjects[2], 85 },
            //    { subjects.Subjects[3], 95 }
            //};
            */

            Admin a1 = new Admin(1, "Test", "Testsky", "test", "test123");
            Admin a2 = new Admin(2, "Bob", "Bobsky", "bobAdmin", "123bobAdmin");
            ListOfAdmins(admins, a1);
            ListOfAdmins(admins, a2);
            //END ADMIN

            Trainer t1 = new Trainer(1, "Bob", "Bobsky", "bob1", "bob123");
            Trainer t2 = new Trainer(1, "Jane", "Janeski", "jane", "jane123");
            ListOfTrainers(trainers, t1);
            ListOfTrainers(trainers, t2);
            //END TRAINER

            Dictionary<string, int> gradesForS1 = AddGradesToSubjects(new List<Subject> { subjects }, new int[] { 0, 2, 3 }, new[] { 90, 80, 95 });
            List<Subject> subjectsForS1 = AddSubjectsToStudent(new List<Subject> { subjects }, new int[] { 0, 3, 2, 5 });

            Dictionary<string, int> gradesForS2 = AddGradesToSubjects(new List<Subject> { subjects }, new int[] { 0, 2, 3, 4 }, new[] { 90, 80, 95, 78 });
            List<Subject> subjectsForS2 = AddSubjectsToStudent(new List<Subject> { subjects }, new int[] { 0, 3, 2, 4, 5 });

            Student s1 = new Student(1, "Bob", "Bobsky", "bob1", "bob123", subjectsForS1, gradesForS1);
            Student s2 = new Student(1, "Jane", "Janeski", "jane", "jane123", subjectsForS2, gradesForS2);
            ListOfStudents(students, s1);
            ListOfStudents(students, s2);
            // END STUDENT

            //BEGIN MAIN
            while (true)
            {
                Console.WriteLine("Welcome, enter role to log in as:\n" +
                              "1. Admin\n" +
                              "2. Trainer\n" +
                              "3. Student");
                if (!int.TryParse(Console.ReadLine(), out int role))
                {
                    Console.WriteLine("Wrong data entered.");
                    continue;
                }

                string username, password;
                switch (role)
                {
                    case 1:
                        Console.WriteLine("Enter username and password for Admin");
                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        Admin loggedAdmin = LogInAdmin(admins, username, password);
                        if (loggedAdmin == null)
                        {
                            Console.WriteLine("Invalid username or password");
                            continue;
                        }

                        Console.WriteLine($"Welcome Admin {loggedAdmin.GetName()}");

                        while (true)
                        {
                            Console.WriteLine("Choose an option:\n" +
                                              "1. Add Trainer\n" +
                                              "2. Remove Trainer\n" +
                                              "3. Add Student\n" +
                                              "4. Remove Student\n" +
                                              "5. Add Admin\n" +
                                              "6. Remove Admin\n");

                            if (!int.TryParse(Console.ReadLine(), out int option))
                            {
                                Console.WriteLine("Wrong input. Enter numbers from 1 to 6");
                                continue;
                            }

                            try
                            {


                                switch (option)
                                {

                                    case 1: //add trainer
                                        int newTrainerId;
                                        while (true)
                                        {
                                            Console.WriteLine("New Trainer ID:");
                                            if (!int.TryParse(Console.ReadLine(), out newTrainerId))
                                            {
                                                Console.WriteLine("Enter valid number.");
                                                continue;
                                            }
                                            break;
                                        }
                                        
                                        Console.WriteLine("New Trainer Firs Name:");
                                        string newTrainerFirstName = Console.ReadLine();
                                        Console.WriteLine("New Trainer Last Name:");
                                        string newTrainerLastName = Console.ReadLine();
                                        Console.WriteLine("New Trainer Username:");
                                        string newTrainerUsername = Console.ReadLine();
                                        Console.WriteLine("New Trainer Password:");
                                        string newTrainerPassword = Console.ReadLine();

                                        Trainer newTrainer = new Trainer(newTrainerId, newTrainerFirstName,
                                            newTrainerLastName, newTrainerUsername, newTrainerPassword);

                                        ListOfTrainers(trainers, newTrainer);

                                        Console.WriteLine(
                                            $"New trainer with username {newTrainer.Username} was added.");

                                        break;
                                    case 2: //remove trainer

                                        Console.WriteLine("Enter the username of the Trainer to be removed");
                                        string inputToRemoveTrainer = Console.ReadLine();

                                        Trainer trainerToRemove =
                                            trainers.Find(t => t.Username == inputToRemoveTrainer);
                                        if (trainerToRemove == null)
                                        {
                                            Console.WriteLine("No Trainer by that username.");
                                        }
                                        else
                                        {
                                            trainers.Remove(trainerToRemove);
                                            Console.WriteLine($"The trainer {inputToRemoveTrainer} was removed.");
                                        }

                                        break;
                                    case 3: //add student
                                        int newStudentId;
                                        while (true)
                                        {
                                            Console.WriteLine("New Student ID:");
                                            if(!int.TryParse(Console.ReadLine(), out newStudentId))
                                            {
                                                Console.WriteLine("Enter valid number.");
                                                continue;
                                            }
                                            break;
                                        }
                                        
                                        Console.WriteLine("New Student Firs Name:");
                                        string newStudentFirstName = Console.ReadLine();
                                        Console.WriteLine("New Student Last Name:");
                                        string newStudentLastName = Console.ReadLine();
                                        Console.WriteLine("New Student Username:");
                                        string newStudentUsername = Console.ReadLine();
                                        Console.WriteLine("New Student Password:");
                                        string newStudentPassword = Console.ReadLine();

                                        int[] arrayOfSubjects = new int[0];
                                        int[] arrayOfGrades = new int[0];

                                        while (true)
                                        {
                                            Console.WriteLine("Enter subjects numbers to add to the student:");
                                            Console.WriteLine("1. Math\n" +
                                                              "2. Science\n" +
                                                              "3. Gym\n" +
                                                              "3. English\n" +
                                                              "4. Literature\n" +
                                                              "5. Chemistry\n" +
                                                              "6. Physics\n" +
                                                              "7. Art\n" +
                                                              "8. History\n" +
                                                              "9. Music\n");
                                            string addSubjectsToStudent = Console.ReadLine();
                                            int[] parsedArrayOfInputs = null;
                                            string[] arrayOfInputs = addSubjectsToStudent.Split(' ');



                                            for (int i = 0; i < arrayOfInputs.Length; i++)
                                            {
                                                if (!int.TryParse(arrayOfInputs[i], out int result) || result < 1 ||
                                                    result > subjects.Subjects.Count)
                                                {
                                                    Console.WriteLine("Invalid input. Please enter a number from 1 to 9.");
                                                    continue;
                                                }

                                                Console.WriteLine($"Enter grade for the subject {subjects.Subjects[result - 1]}:");
                                                if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 0 ||
                                                    grade > 100)
                                                {
                                                    Console.WriteLine("Invalid grade. Please enter a valid grade (0-100).");
                                                    continue;
                                                }

                                                Array.Resize(ref arrayOfSubjects, arrayOfSubjects.Length + 1);
                                                arrayOfSubjects[arrayOfSubjects.Length - 1] = result;
                                                //arrayOfSubjects[i] = result;

                                                Array.Resize(ref arrayOfGrades, arrayOfGrades.Length + 1);
                                                arrayOfGrades[arrayOfGrades.Length - 1] = grade;
                                                //arrayOfGrades[i] = grade;
                                            }

                                            /*
                                            //foreach (string number in arrayOfInputs)
                                            //{
                                            //    if (!int.TryParse(number, out int result))
                                            //    {
                                            //        Console.WriteLine("Please enter numbers.");
                                            //        continue;
                                            //    }

                                            //    while (true)
                                            //    {
                                            //        Console.WriteLine(
                                            //            $"Enter grade for the subject {subjects.Subjects[result]}");
                                            //        if (!int.TryParse(Console.ReadLine(), out int grade) && grade > 100)
                                            //        {
                                            //            Console.WriteLine("Wrong input.");
                                            //            continue;
                                            //        }


                                            //    }
                                            //}
                                            */
                                            break;
                                        }


                                        Dictionary<string, int> gradesForNewStudent =
                                            AddGradesToSubjects(new List<Subject> { subjects }, arrayOfSubjects,
                                                arrayOfGrades);
                                        List<Subject> subjectsForNewStudent =
                                            AddSubjectsToStudent(new List<Subject> { subjects }, arrayOfSubjects);

                                        Student newStudent = new Student(newStudentId, newStudentFirstName,
                                            newStudentLastName, newStudentUsername, newStudentPassword,
                                            subjectsForNewStudent, gradesForNewStudent);

                                        Console.WriteLine($"Added the student: {newStudent.GetName()}");
                                        //ListOfStudents(students, newStudent);
                                        break;
                                    case 4: //remove student

                                        Console.WriteLine("Enter the username of the Trainer to be removed");
                                        string inputToRemoveStudent = Console.ReadLine();

                                        Student studentToRemove =
                                            students.Find(s => s.Username == inputToRemoveStudent);
                                        if (studentToRemove == null)
                                        {
                                            Console.WriteLine("No Trainer by that username.");
                                        }
                                        else
                                        {
                                            students.Remove(studentToRemove);
                                            Console.WriteLine($"The trainer {inputToRemoveStudent} was removed.");
                                        }

                                        break;
                                    case 5: //add admin
                                        int newAdminId;

                                        while (true)
                                        {
                                            Console.WriteLine("New Admin ID:");
                                            if (!int.TryParse(Console.ReadLine(), out newAdminId))
                                            {
                                                Console.WriteLine("Enter valid number.");
                                                continue;
                                            }
                                            break;
                                        }
                                        
                                        Console.WriteLine("New Admin Firs Name:");
                                        string newAdminFirstName = Console.ReadLine();
                                        Console.WriteLine("New Admin Last Name:");
                                        string newAdminLastName = Console.ReadLine();
                                        Console.WriteLine("New Admin Username:");
                                        string newAdminUsername = Console.ReadLine();
                                        Console.WriteLine("New Admin Password:");
                                        string newAdminPassword = Console.ReadLine();

                                        Admin newAdmin = new Admin(newAdminId, newAdminFirstName, newAdminLastName,
                                            newAdminUsername, newAdminPassword);

                                        ListOfAdmins(admins, newAdmin);

                                        Console.WriteLine($"The admin with username {newAdmin.Username} was added.");
                                        break;
                                    case 6: //remove admin

                                        Console.WriteLine("Enter the username of the Trainer to be removed");
                                        string inputToRemoveAdmin = Console.ReadLine();

                                        Admin adminToRemove = admins.Find(s => s.Username == inputToRemoveAdmin);
                                        if (adminToRemove == null)
                                        {
                                            Console.WriteLine("No Trainer by that username.");
                                        }
                                        else if (adminToRemove.Username == loggedAdmin.Username)
                                        {
                                            Console.WriteLine("Cannot remove yourself.");
                                        }
                                        else
                                        {
                                            admins.Remove(adminToRemove);
                                            Console.WriteLine($"The trainer {inputToRemoveAdmin} was removed.");
                                        }

                                        break;
                                    default:
                                        Console.WriteLine("Enter numbers from 1 to 6");
                                        continue;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }

                            break;
                        }

                        break;

                    case 2:
                        Console.WriteLine("Enter username and password for Trainer");
                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        Trainer loggedTrainer = LogInTrainer(trainers, username, password);
                        if (loggedTrainer == null)
                        {
                            Console.WriteLine("Invalid username or password");
                            continue;
                        }

                        Console.WriteLine($"Welcome Trainer {loggedTrainer.GetName()}");

                        while (true)
                        {
                            Console.WriteLine("Choose an option:");
                            Console.WriteLine("1. List all students\n" +
                                              "2. Enter student name\n" +
                                              "3. Subjects");
                            if (!int.TryParse(Console.ReadLine(), out int trainerOption))
                            {
                                Console.WriteLine("Invalid command. Enter numbers from 1 to 3");
                                continue;
                            }

                            switch (trainerOption)
                            {
                                case 1:
                                    Console.WriteLine("List of all students:");
                                    Console.WriteLine(ListAllStudents(students));
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        Console.WriteLine("Enter a name of a student:");
                                        string student = Console.ReadLine();
                                        if (student.Length < 3)
                                        {
                                            Console.WriteLine("Enter minimum 3 letters.");
                                            continue;
                                        }

                                        Student foundStudent = FindStudent(students, student);

                                        if (foundStudent == null)
                                        {
                                            Console.WriteLine("No student by that name.");
                                            continue;
                                        }

                                        Console.WriteLine(foundStudent.GetSubjects());

                                        break;
                                    }

                                    break;
                                case 3:
                                    while (true)
                                    {
                                        Console.WriteLine("Enter subject: ");
                                        string subject = Console.ReadLine();

                                        string result = SubjectsAttendance(students, subject);
                                        if (result == null)
                                        {
                                            Console.WriteLine("Enter valid subject name");
                                            continue;
                                        }

                                        Console.WriteLine(result);
                                        break;
                                    }


                                    break;
                                default:
                                    Console.WriteLine("Invalid command. Enter numbers from 1 to 3");
                                    continue;
                            }

                            break;
                        }

                        break;

                    case 3:
                        Console.WriteLine("Enter username and password for Student");
                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        Student loggedStudent = LogInStudent(students, username, password);
                        if (loggedStudent == null)
                        {
                            Console.WriteLine("Invalid username or password");
                            continue;
                        }

                        //Console.WriteLine($"Welcome Student {loggedStudent.GetName()}");
                        //Console.WriteLine("Your subjects are:");
                        //Console.WriteLine(loggedStudent.GetSubjects());
                        //Console.WriteLine("Your grades are:");
                        //Console.WriteLine(loggedStudent.GetGrades());

                        Console.WriteLine(StudentLogged(loggedStudent));
                        break;

                    default:
                        Console.WriteLine("Please enter number 1 to 3");
                        continue;
                }
                break;
            }
        }

        public static void PopulateSubject(Subject subjects)
        {
            subjects.Subjects.Add("Math");
            subjects.Subjects.Add("Science");
            subjects.Subjects.Add("Gym");
            subjects.Subjects.Add("English");
            subjects.Subjects.Add("Literature");
            subjects.Subjects.Add("Chemistry");
            subjects.Subjects.Add("Physics");
            subjects.Subjects.Add("Art");
            subjects.Subjects.Add("History");
            subjects.Subjects.Add("Music");
        }

        public static List<Subject> AddSubjectsToStudent(List<Subject> subjects, int[] index)
        {
            List<Subject> result = new List<Subject>();
            foreach (var subject in subjects)
            {
                Subject selectedSubject = new Subject();
                foreach (int i in index)
                {
                    if (i >= 0 && i < subject.Subjects.Count)
                    {
                        selectedSubject.Subjects.Add(subject.Subjects[i]);
                    }
                }
                result.Add(selectedSubject);
            }
            return result;
        }

        public static Dictionary<string, int> AddGradesToSubjects(List<Subject> subjects, int[] index, int[] grade)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var subject in subjects)
            {
                int j = 0;
                //Subject selectedSubject = new Subject();
                foreach (int i in index)
                {
                    //if (i >= 0 && i < grade.Length)
                    {
                        result.Add(subject.Subjects[i], grade[j]);
                        j++;
                    }
                }
            }
            return result;
        }

        public static Admin LogInAdmin(List<Admin> admins, string username, string password)
        {
            Admin admin = admins.Find(a => a.Username == username && a.ValidatePassword(password));
            //Console.WriteLine(a.Username);
            //if (a == null)
            //{
            //    return a;
            //}

            return admin;

        }
        public static Trainer LogInTrainer(List<Trainer> trainers, string username, string password)
        {
            Trainer trainer = trainers.Find(t => t.Username == username && t.ValidatePassword(password));
            return trainer;
        }
        public static Student LogInStudent(List<Student> students, string username, string password)
        {
            Student student = students.Find(s => s.Username == username && s.ValidatePassword(password));
            return student;
        }
        public static List<Admin> ListOfAdmins(List<Admin> admins, Admin admin)
        {
            admins.Add(admin);
            return admins;
        }
        public static List<Trainer> ListOfTrainers(List<Trainer> trainers, Trainer trainer)
        {
            trainers.Add(trainer);
            return trainers;
        }
        public static List<Student> ListOfStudents(List<Student> students, Student student)
        {
            students.Add(student);
            return students;
        }

        public static string LoggedAdmin(Admin admin)
        {
            return "";
        }

        public static string SubjectsAttendance(List<Student> students, string subjectToCheck)
        {
            Dictionary<string, int> subjectCounts = new Dictionary<string, int>();

            // Iterate over each student and their subjects
            foreach (var student in students)
            {
                foreach (var subject in student.Subjects)
                {
                    foreach (var subjectName in subject.Subjects)
                    {
                        if (subjectCounts.ContainsKey(subjectName))
                        {
                            // If subject exists, increment count
                            subjectCounts[subjectName]++;
                        }
                        else
                        {
                            // If subject doesn't exist, add it with count 1
                            subjectCounts[subjectName] = 1;
                        }
                    }
                }
            }

            if (subjectCounts.ContainsKey(subjectToCheck))
            {
                int count = subjectCounts[subjectToCheck];
                return $"Number of students attending {subjectToCheck}: {count}";
            }

            return null;
        }


        public static string ListAllStudents(List<Student> students)
        {
            string result = "";
            foreach (var student in students)
            {
                result += $"{student.GetName()}\n";
            }


            return result;
        }

        public static Student FindStudent(List<Student> students, string name)
        {
            Student student = students.Find(s => s.FirstName == name);

            return student;
        }
        public static string StudentLogged(Student student)
        {
            string result = $"Welcome Student {student.GetName()}\n" +
                            $"Your subjects are:\n{student.GetSubjects()}\n" +
                            $"Your grades are:\n{student.GetGrades()}";

            return result;
        }
    }
}
