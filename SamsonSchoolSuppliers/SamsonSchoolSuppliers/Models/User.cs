using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamsonSchoolSuppliers.Models
{
    public class User
    {
        public int User_Id { get; set; }
        public string U_Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string User_Type { get; set; }
        public string Password { get; set; }

    }
}