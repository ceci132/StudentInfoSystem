using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        public static List<Student> TestStudents { get; private set; } = new List<Student> { 
            new Student("Tsvetan", "Krasimirov", "Ivanov", "FKST", "CSE", "Bachelor", "active", "121219083", 3, 9, 29),
            new Student("Martin", "Ivanov", "Krasimirov", "FKST", "CSE", "Bachelor", "active", "121218", 3, 9, 29)};
      
        public static Student getStudentByFacultyNumber(String facultyNumber)
        {
            foreach(Student student in TestStudents)
            {
                if(student.facultyNumber.Equals(facultyNumber))
                {
                    return student;
                }
            }

            return null;
        }

        public static Student getStudentByName(String name, String surname, String lastName)
        {
            foreach (Student student in TestStudents)
            {
                if (student.name.Equals(name) && student.surname.Equals(surname) && student.lastName.Equals(lastName))
                {
                    return student;
                }
            }

            return null;
        }

        public static Student getDefaultStudent()
        {
            return TestStudents.ElementAt(0);
        }
        
    }
}
