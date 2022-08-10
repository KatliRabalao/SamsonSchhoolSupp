using SamsonSchoolSuppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace SamsonSchoolSuppliers.Controllers
{
    public class SchoolController : Controller
    {
        SamsonSchoolSuppDataContext db = new SamsonSchoolSuppDataContext();
        // Adding school...this is performed by the Administrator
        [Route("api/school/addSchool")]
        [HttpPost]

        public string addSchool([FromBody] School objectuser)
        {

            var dev = (from u in db.School_tbls
                       where u.School_ID.Equals(objectuser.School_ID)
                       select u).FirstOrDefault();
            if (dev != null)
            {
                return "Please try again";
            }
            else
            {

                var newSchool = new School_tbl
                {
                    School_ID = objectuser.School_ID,
                    S_Name = objectuser.S_Name,
                   S_Address = objectuser.S_Address,
                   Cell_Number=objectuser.Cell_Number
                   

                };
                db.School_tbls.InsertOnSubmit(newSchool);

                try
                {


                    db.SubmitChanges();
                    return "School added Succesfully";
                   
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return "Error adding School";
                }
            }
        }
        [Route("api/school/deleteSchool/{id}")]
        [HttpGet]
        public string deleteSchool(int id)
        {
            var deleteschool = (from u in db.School_tbls
                                where u.School_ID.Equals(id)
                                select u).FirstOrDefault();


            try
            {


                db.School_tbls.DeleteOnSubmit(deleteschool);

                db.SubmitChanges();

                return "School deleted successfully";

            }
            catch (Exception e)
            {

                e.GetBaseException();
                return "Error occured when deleting";
            }
        }


    }
}