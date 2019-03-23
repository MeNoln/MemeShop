using System.ComponentModel.DataAnnotations;

namespace MemeShop.Models
{
    public class ShopItemViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
    }
}