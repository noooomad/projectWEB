using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ViewResult UserIndex()
        {
            RestaurantEntities db = new RestaurantEntities();
            return View(db.Users);
        }

        public ViewResult ItemIndex()
        {
            RestaurantEntities db = new RestaurantEntities();
            return View(db.Items);
        }

        public ViewResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserCreate(User us)
        {
            RestaurantEntities db = new RestaurantEntities();

            db.Users.Add(us);
            db.SaveChanges();

            return RedirectToAction("UserIndex");
        }

        public ViewResult ItemCreate()
        {
            ItemCategoryModel model = new ItemCategoryModel();
            RestaurantEntities db = new RestaurantEntities();

            // Populate the category list
            model.CategoryList = db.Categories.Select(c => new SelectListItem
            {
                Value = c.Category_ID.ToString(),
                Text = c.Category_Name.ToString(),
            }).ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult ItemCreate(ItemCategoryModel icModel)
        {
            RestaurantEntities db = new RestaurantEntities();

            Item item = new Item();
            item.Item_Price = icModel.item.Item_Price;
            item.Item_Name = icModel.item.Item_Name;
            item.Item_Desc = icModel.item.Item_Desc;

            if (icModel.thePic != null && icModel.thePic.ContentLength > 0)
            {
                string fileName = Path.GetFileName(icModel.thePic.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                icModel.thePic.SaveAs(filePath);
                item.Item_Image = "/images/" + fileName;
                // Additional processing or saving logic here
            }

            //var Category = db.Categories
            //.Where(model => model.Category_ID == icModel.SelectedCategoryID)
            //.FirstOrDefault();

            db.Items.Add(item);
            //db.SaveChanges(); 

            CategoryItem catItem = new CategoryItem();
            catItem.Category_ID = icModel.SelectedCategoryID;
            catItem.Item_ID = item.Item_ID;

            db.CategoryItems.Add(catItem);
            db.SaveChanges();

            return RedirectToAction("ItemIndex");
        }


        public ActionResult ItemDelete(int id)
        {
            RestaurantEntities db = new RestaurantEntities();
            Item model = db.Items.Find(id);
            if (model != null)
            {
                List<CartItem> cartitem = db.CartItems.Where(s => s.Item_ID == id).ToList();
                List<CategoryItem> categoryitem = db.CategoryItems.Where(s => s.Item_ID == id).ToList();
                foreach (var item in cartitem)
                {
                    db.CartItems.Remove(item);
                }
                foreach (var itemC in categoryitem)
                {
                    db.CategoryItems.Remove(itemC);
                }
                db.Items.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("ItemIndex");
        }

        public ActionResult UserDelete(int id)
        {
            RestaurantEntities db = new RestaurantEntities();
            User model = db.Users.Find(id);
            if (model != null)
            {
                List<UserRole> cartitem = db.UserRoles
                    .Where(s => s.User_ID == id)
                    .ToList();

                foreach (var item in cartitem)
                {
                    db.UserRoles.Remove(item);
                }
                db.Users.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("UserIndex");
        }

        public ActionResult Edit(int id)
        {
            RestaurantEntities db = new RestaurantEntities();
            Item us = db.Items.Find(id);
            ViewBag.isEdit = true;
            return View("Edit", us);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase itemPhoto, string itemName, string itemPrice, int Item_ID)
        {
            RestaurantEntities db = new RestaurantEntities();

            Item us = db.Items.Find(Item_ID);
            us.Item_Name = itemName;
            us.Item_Price = float.Parse(itemPrice);

            if (itemPhoto != null && itemPhoto.ContentLength > 0)
            {
                string fileName = Path.GetFileName(itemPhoto.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Content/images/product"), fileName);
                itemPhoto.SaveAs(filePath);
                us.Item_Image = "/Content/images/product/" + fileName;
                // Additional processing or saving logic here
            }


            db.Entry<Item>(us).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}