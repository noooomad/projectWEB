using BusinessLogic.DB;
using Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class RezervationController : Controller
    {
        // GET: Rezervation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sucess(string persons, string Date, string Time)
        {
            RestaurantEntities db = new RestaurantEntities();

            var user = db.Users
                .Where(m => m.User_Login == HttpContext.User.Identity.Name)
                .FirstOrDefault();

            Reservation rezervation = new Reservation();
            rezervation.Reserv_Number = int.Parse(persons);
            rezervation.Reserv_Date = DateTime.Now;
            rezervation.User = user;

            string output = Regex.Replace(Time, "(AM|PM)", string.Empty).Trim();

            rezervation.Reserv_Time = TimeSpan.ParseExact(output, @"h\:mm", null);

            if (db.Reservations
                .Where(m => m.Reserv_Time == rezervation.Reserv_Time && m.Reserv_Date == rezervation.Reserv_Date)
                .FirstOrDefault() != null)
            {
                return View();
            }
            else
            {
                db.Reservations.Add(rezervation);
                db.SaveChanges();
                BookedModel bModel = new BookedModel();
                bModel.persons = persons;
                bModel.time = Time;
                bModel.date = Date;
                return View(bModel);
            }
        }

        [HttpGet]
        public ActionResult Sucess()
        {
            return View();
        }
    }
}