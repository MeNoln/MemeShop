namespace DAL.EF6
{
    using DAL.Entities;
    using System.Data.Entity;

    public class ShopItemContext : DbContext
    {
        
        public ShopItemContext(string connect)
            : base("name=ShopItemContext")
        {
        }

        public DbSet<ShopItem> ShopItems { get; set; }
        
    }

    
}