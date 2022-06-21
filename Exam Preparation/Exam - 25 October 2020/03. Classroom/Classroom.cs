using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Students = new List<Student>();
            Capacity = capacity;
        }

        public List<Student> Students { get; set; }
        public int Capacity { get; set; }
        public int Count => Students.Count();

        public string RegisterStudent(Student student)
        {
            if (Students.Count>=Capacity)
            {
                return "No seats in the classroom";
            }
            else
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student currStudent = Students.FirstOrDefault(s => s.FirstName == firstName 
                                 && s.LastName == lastName);
            if (!Students.Contains(currStudent))
            {
                return "Student not found";
            }
            else
            {
                Students.Remove(currStudent);
                return $"Dismissed student {currStudent.FirstName} {currStudent.LastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> students = Students.Where(s => s.Subject == subject).ToList();

            if (students.Count==0)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in students)
                {
                
                    sb.AppendLine($"{student.FirstName} { student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            
            
            
        }

        public  int GetStudentsCount
        {
            get { return Students.Count(); }
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.FirstOrDefault(s => s.FirstName == firstName &&
                                    s.LastName == lastName);
        }
    }
}
