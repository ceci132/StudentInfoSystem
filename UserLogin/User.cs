using System;

namespace UserLogin
{
    public class User
    {
        public String username { get; set; }
        public String password { get; set; }
        public String facultyNumber { get; set; }
        public int role { get; set; }
        public DateTime created { get; set; }
        public DateTime validToDate { get; set; }
    }
}
