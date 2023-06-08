using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [Authorize]
        public ActionResult Index()
        {
            RestaurantEntities re = new RestaurantEntities();

            var _user = re.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            List<Item> items = re.CartItems
                .Where(model => model.Cart.User_ID == _user.User_ID)
                .Select(model => model.Item)
                .ToList();

            double sum = 0;
            foreach (var item in items)
            {
                sum += item.Item_Price;
            }
            //List<CartItem> cItems = re.CartItems.Where(model => model.Cart.User_ID == _user.User_ID).ToList();

            // calculate total price
            // pass only items

            CartItemsModel theModel = new CartItemsModel();
            theModel.cartItems = items;
            theModel.TotalPrice = Math.Round(sum, 2);
            
            return View(theModel);
        }
    }

}