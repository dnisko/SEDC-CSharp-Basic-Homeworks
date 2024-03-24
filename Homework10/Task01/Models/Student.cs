using System.Diagnostics;
using System.Globalization;

namespace Task01.Models
{
    public class Student : Person
    {
        public List<Subject> Subjects { get; set; }
        public Dictionary<string, int> Grades { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }

        public Student(int id, string firstName, string lastName, string username, string password, List<Subject> subjects, Dictionary<string, int> grades)
            : base(id, firstName, lastName)
        {
            Username = username;
            Password = password;
            Subjects = subjects;
            Grades = grades;
        }

        public bool ValidatePassword(string password)
        {
            return Password == password;
        }

        public override string GetName()
        {
            return $"Name: {FirstName}, Lastname: {LastName}";
        }

        public string GetSubjects()
        {
            string result = "You are enrolled in subjects:\n";
            foreach (Subject subject in Subjects)
            {
                foreach (string subjectsForUser in subject.Subjects)
                {
                    result += $"{subjectsForUser}\n";
                }
            }

            //couldn't get it to work this way... 
            //Subjects.ForEach(s => result += s);

            return result;
        }
        public string GetGrades()
        {
            //student.Grades[subject] = grade;
            string result = "Your grades:\n";
            foreach (var grade in Grades) //intellisense helped a lot with 'var' :)
            {
                result += $"{grade.Key} {grade.Value}\n";
            }
            return result;
        }
    }
}
