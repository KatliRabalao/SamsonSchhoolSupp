using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamsonSchoolSuppliers.Models
{
    public class Item
    {
        public int Item_ID { get; set; }
        public string I_Name { get; set; }
        public string I_Description { get; set; }
        public string I_UnitPrice { get; set; }
    }
}