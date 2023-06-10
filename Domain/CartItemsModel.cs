using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CartItemsModel
    {
        public List<Item> cartItems { get; set; }
        public double TotalPrice { get; set; }
      
    }
}
