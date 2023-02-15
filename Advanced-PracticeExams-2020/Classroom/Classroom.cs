using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(); 
        }
        public int Capacity { get; set; } 
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if(Count == Capacity)
            {
                return "No seats in the classroom";
            }
            
            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student removed = null;
            for(int i = 0; i < students.Count; i++)
            {
                if(students[i].FirstName == firstName && students[i].LastName == lastName)
                {
                    removed = students[i];
                    students.RemoveAt(i);
                    break;
                }

            }

            if(removed == null)
            {
                return "Student not found";
            }
            else
            {
                return $"Dismissed student {firstName} {lastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder str = new StringBuilder();
            int counter = 0;
            str.AppendLine($"Subject: {subject}");
            str.AppendLine("Students:");
            foreach(Student student in students)
            {
                if(student.Subject == subject)
                {
                    counter++;
                    str.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }

            if(counter == 0)
            {
                return "No students enrolled for the subject";
            }

            return str.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            foreach(Student student in students)
            {
                if(student.FirstName == firstName && student.LastName == lastName)
                {
                    return student;
                }
            }
            return null;
        }
    }
}
