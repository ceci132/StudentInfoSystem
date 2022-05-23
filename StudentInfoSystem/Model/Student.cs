using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String lastName { get; set; }
        public String faculty { get; set; }
        public String specialty { get; set; }
        public String degree { get; set; }
        public String status { get; set; }
        public String facultyNumber { get; set; }
        public int courseYear { get; set; }
        public int stream { get; set; }
        public int group { get; set; }

        public Student(string name, string surname, string lastName, string faculty, string specialty, string degree, string status, String facultyNumber, int courseYear, int stream, int group)
        {
            this.name = name;
            this.surname = surname;
            this.lastName = lastName;
            this.faculty = faculty;
            this.specialty = specialty;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.courseYear = courseYear;
            this.stream = stream;
            this.group = group;
        }
    }
}
