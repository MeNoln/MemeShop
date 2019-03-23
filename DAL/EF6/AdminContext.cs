namespace DAL.EF6
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdminContext : DbContext
    {
        public AdminContext(string connect)
            : base("name=MemeShopDatabase")
        {
        }
        public DbSet<Admin> Admins { get; set; }
        
    }

    
}