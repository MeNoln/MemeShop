using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Utilities
{
    public class NinjectUtil : NinjectModule
    {
        public override void Load()
        {
            Bind<IShopItemService>().To<ShopItemService>();
        }
    }
}