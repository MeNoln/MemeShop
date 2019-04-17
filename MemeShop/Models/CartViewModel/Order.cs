using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Models.CartViewModel
{
    public class Order
    {
        public ShopItemViewModel shopItemViewModel { get; set; }
        public string size { get; set; }
    }
}