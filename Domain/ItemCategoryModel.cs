using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Domain
{
    public class ItemCategoryModel
    {
        public Item item { get; set; }
        public int SelectedCategoryID { get; set; }
        //public List<Category> categories { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public HttpPostedFileBase thePic { get; set; }
    }
}
