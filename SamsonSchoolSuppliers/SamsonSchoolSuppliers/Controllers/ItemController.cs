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
    public class ItemController : Controller
    {

        SamsonSchoolSuppDataContext db = new SamsonSchoolSuppDataContext();
        // Adding school...this is performed by the Administrator
        [Route("api/item/addItem")]
        [HttpPost]

        public string addItem([FromBody] Item objectuser)
        {

            var dev = (from u in db.Item_tbls
                       where u.Item_ID.Equals(objectuser.Item_ID)
                       select u).FirstOrDefault();
            if (dev != null)
            {
                return "Please try again";
            }
            else
            {

                var newItem = new Item_tbl
                {
                    Item_ID = objectuser.Item_ID,
                    I_Name = objectuser.I_Name,
                    I_Description = objectuser.I_Description,
                    I_UnitPrice = objectuser.I_UnitPrice


                };
                db.Item_tbls.InsertOnSubmit(newItem);

                try
                {


                    db.SubmitChanges();
                    return "Item added Succesfully";

                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return "Error adding Item";
                }
            }
        }
        [Route("api/item/removeItem/{id}")]
        [HttpGet]
        public string removeItem(int id)
        {
            var removeitem = (from u in db.Item_tbls
                                where u.Item_ID.Equals(id)
                                select u).FirstOrDefault();


            try
            {


                db.Item_tbls.DeleteOnSubmit(removeitem);

                db.SubmitChanges();

                return "Item removed successfully";

            }
            catch (Exception e)
            {

                e.GetBaseException();
                return "Error occured while removing Item";
            }
        }


        /*
         * 
         * TESTING
         * 
         * 
         */
        [Route("api/item/getItem/{id}")]
        [HttpGet]
        public List<Item> getItem(int id)
        {
            List<Item> add = new List<Item>();
            dynamic hh = (from u in db.Item_tbls
                          where u.Item_ID.Equals(id)
                          select u);
            if (hh != null)
            {
                foreach (Item_tbl ob in hh)
                {
                    Item myob = new Item
                    {
                       
                        Item_ID = ob.Item_ID,
                        I_Name= ob.I_Name,
                        I_Description = ob.I_Description,
                        I_UnitPrice = ob.I_UnitPrice,
                      

                    };
                    add.Add(myob);
                }


            }

            return add;

        }



        // GET: Item
        public ActionResult Index()
        {
            return View();
        }
    }
}