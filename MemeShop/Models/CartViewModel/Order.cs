using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Models.CartViewModel
{
    //Order View Model
    public class Order
    {
        public ShopItemViewModel shopItemViewModel { get; set; }
        public string size { get; set; }
    }
}