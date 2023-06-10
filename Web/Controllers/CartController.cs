using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        [Authorize]
        public ActionResult Index()
        {
            RestaurantEntities re = new RestaurantEntities();

            var _user = re.Users
                .Where(s => s.User_Login == HttpContext.User.Identity.Name)
                .FirstOrDefault();

            List<Item> items = re.CartItems
                .Where(model => model.Cart.User_ID == _user.User_ID)
                .Select(model => model.Item)
                .ToList();

            double sum = 0;
            foreach (var item in items)
            {
                sum += item.Item_Price;
            }

            CartItemsModel theModel = new CartItemsModel();
            theModel.cartItems = items;
            theModel.TotalPrice = Math.Round(sum, 2);

            return View(theModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var re = new RestaurantEntities();

            var _user = re.Users
                .Where(s => s.User_Login == HttpContext.User.Identity.Name)
                .FirstOrDefault();

            var _cart = re.Carts
                .Where(s => s.User_ID == _user.User_ID)
                .FirstOrDefault();

            var _cartItem = re.CartItems
                .Where(s => s.Item_ID == id && _cart.Cart_ID == s.Cart_ID)
                .FirstOrDefault();

            re.CartItems.Remove(_cartItem);
            re.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Purchase()
        {
            return View();
        }
        public ActionResult Sucess()
        {
            return View();
        }
    }

}