namespace DAL.EF6
{
    using DAL.Entities;
    using System.Data.Entity;

    //Data context(code first)
    public class DiscountContext : DbContext
    {
        public DiscountContext(string connect)
            : base("name=MemeShopDatabase")
        {
        }

        //Discount codes Table
        public DbSet<DiscountCode> DiscountCodes { get; set; }

    }

    
}