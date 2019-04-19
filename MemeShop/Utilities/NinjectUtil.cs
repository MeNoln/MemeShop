using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Utilities
{
    //Binding Service Interfaces with Inherited classes
    public class NinjectUtil : NinjectModule
    {
        public override void Load()
        {
            Bind<IShopItemService>().To<ShopItemService>();
            Bind<IAdminSevice>().To<AdminService>();
            Bind<IDiscountCodeService>().To<DiscountCodeService>();
        }
    }
}