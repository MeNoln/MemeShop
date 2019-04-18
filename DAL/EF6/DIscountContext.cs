namespace DAL.EF6
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DiscountContext : DbContext
    {
        public DiscountContext(string connect)
            : base("name=MemeShopDatabase")
        {
        }
        public DbSet<DiscountCode> DiscountCodes { get; set; }

    }

    
}