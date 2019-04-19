namespace DAL.EF6
{
    using DAL.Entities;
    using System.Data.Entity;

    //Data Context(Code First)
    public class ShopItemContext : DbContext
    {
        
        public ShopItemContext(string connect)
            : base("name=MemeShopDatabase")
        {
        }

        //Shop items table
        public DbSet<ShopItem> ShopItems { get; set; }
        
    }

    
}