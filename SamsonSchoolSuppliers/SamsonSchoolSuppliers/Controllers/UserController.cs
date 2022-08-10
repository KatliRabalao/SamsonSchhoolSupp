using SamsonSchoolSuppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace SamsonSchoolSuppliers.Controllers
{
    public class UserController : Controller
    {
        SamsonSchoolSuppDataContext db = new SamsonSchoolSuppDataContext();
        [Route("api/user/login")]
        [HttpPost]
        public int login([System.Web.Http.FromBody] User objectuser)
        {
            var information = (from u in db.User_tbls
                               where u.Email.Equals(objectuser.Email) && u.Password.Equals(objectuser.Password)
                               select u).FirstOrDefault();

            if (information == null)
            {
                return -1;
            }
            else
            {
                return information.User_ID;
            }
        }

        //admin login
        [Route("api/user/adminlogin")]
        [HttpPost]
        public string adminlogin([FromBody] User objectuser)
        {
            var information = (from u in db.User_tbls
                               where u.Email.Equals("Admin@gmail.com") && u.Password.Equals("Admin1234")
                               select u).FirstOrDefault();

            if (information == null)
            {
                return "Invalid Sign In Details";
            }
            else
            {
                return "Welcome Admin";
            }
        }

        [Route("api/user/SignUp")]
        [HttpPost]
        public string Registration([FromBody] User ObjectUser)
        {

            var userReg = (from u in db.User_tbls
                           where u.Email.Equals(ObjectUser.Email)
                           select u).FirstOrDefault();


            if (userReg != null)
            {
                return "User already Exist";
            }
            else
            {

                var newUSer = new User_tbl
                {
                    
                    U_Name = ObjectUser.U_Name,
                    Surname = ObjectUser.Surname,
                    Email = ObjectUser.Email,   
                    User_Type = ObjectUser.User_Type,
                    Password = ObjectUser.Password,


                };
                db.User_tbls.InsertOnSubmit(newUSer);

                try
                {

                    db.SubmitChanges();
                    var iddd = (from u in db.User_tbls
                                where u.Email.Equals(ObjectUser.Email)
                                select u).FirstOrDefault();
                    return iddd.User_ID.ToString();

                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return "User could not be added";
                }
            }

        }
    }

}
    
