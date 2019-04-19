using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeShop.Models.DiscountCode
{
    //Discount Code View Model
    public class DiscountCodeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int DiscountPerCent { get; set; }
    }
}