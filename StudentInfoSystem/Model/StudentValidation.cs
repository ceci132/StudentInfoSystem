using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        Student GetStudentDataByUser(User user)
        {
            if ((UserRoles)user.role != UserRoles.STUDENT)
            {
                return null;
            }

            return StudentData.getStudentByFacultyNumber(user.facultyNumber);
        }
    }
}
