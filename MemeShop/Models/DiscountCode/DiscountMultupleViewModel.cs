using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Models.DiscountCode
{
    //Model with Enumerable of all discount codes and current code class
    public class DiscountMultupleViewModel
    {
        public IEnumerable<DiscountCodeViewModel> CodesEnum { get; set; }
        public DiscountCodeViewModel DiscountCodeVM { get; set; }
    }
}