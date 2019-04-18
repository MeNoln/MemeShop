using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Models.DiscountCode
{
    public class DiscountMultupleViewModel
    {
        public IEnumerable<DiscountCodeViewModel> CodesEnum { get; set; }
        public DiscountCodeViewModel DiscountCodeVM { get; set; }
    }
}