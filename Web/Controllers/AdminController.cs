using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            RestaurantEntities db = new RestaurantEntities();
            return View(db.Users);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User us)
        {
            if (ModelState.IsValid)
            {
                RestaurantEntities db = new RestaurantEntities();
                db.Users.Add(us);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid data");
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            RestaurantEntities db = new RestaurantEntities();
            User model = db.Users.Find(id);
            if (model != null)
            {
                List<UserRole> role = db.UserRoles.Where(s => s.User_ID == id).ToList();
                foreach (var item in role)
                {
                    db.UserRoles.Remove(item);
                }
                db.Users.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            RestaurantEntities db = new RestaurantEntities();
            User us = db.Users.Find(id);
            ViewBag.isEdit = true;
            return View("Create", us);
        }

        [HttpPost]
        public ActionResult Edit(User us)
        {
            RestaurantEntities db = new RestaurantEntities();
            db.Entry<User>(us).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}