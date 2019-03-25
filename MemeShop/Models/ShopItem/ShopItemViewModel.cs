using System.ComponentModel.DataAnnotations;

namespace MemeShop.Models
{
    public class ShopItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string PhotoPath { get; set; }
    }
}