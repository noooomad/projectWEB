using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Food(int id)
        {
            RestaurantEntities re = new RestaurantEntities();
            List<Item> items = re.CategoryItems
                .Where(model => model.Category_ID == id)
                .Select(model => model.Item)
                .ToList();
            ItemsModel itemsModel = new ItemsModel();
            itemsModel.Items = items;
            ViewBag.CategoryName = re.Categories.Find(id).Category_Name;
            ViewBag.CategoryID = id;
            return View(itemsModel);
        }

        [HttpPost]
        public ActionResult Food(int Item_id, int? Category_id,string text)
        {
            RestaurantEntities re = new RestaurantEntities();
            Item it = re.Items.Find(Item_id);

            var _user = re.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            Cart cart = re.Carts.Where(model => model.User_ID == _user.User_ID).FirstOrDefault();
            if (cart == null)
            {
                cart = new Cart
                {
                    Cart_Total = 1,
                    User_ID = _user.User_ID,
                };
                re.Carts.Add(cart);
                re.SaveChanges();
            }
            CartItem cartItem = new CartItem();
            cartItem.Cart_ID = cart.Cart_ID;
            cartItem.Item_ID = Item_id;
            re.CartItems.Add(cartItem);
            re.SaveChanges();

            return RedirectToAction("Food", new { id = Category_id });
        }
    }
}