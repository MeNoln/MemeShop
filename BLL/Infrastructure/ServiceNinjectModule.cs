﻿using DAL.Interfaces;
using DAL.Interfaces.UoWPattern;
using DAL.UoWRepository;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    //Inversion of Control container
    //I use Ninject
    public class ServiceNinjectModule : NinjectModule
    {
        private string connection;
        public ServiceNinjectModule(string connection)
        {
            this.connection = connection;
        }

        //Binding Unit of Work Interfaces with class realisations
        public override void Load()
        {
            Bind<IUnitOfWorkPattern>().To<UnitOfWorkRepository>().WithConstructorArgument(connection);
            Bind<IUoWAdminPattern>().To<UoWAdminRepository>();
            Bind<IUoWDIscount>().To<UoWDiscount>().WithConstructorArgument(connection);
        }
    }
}
