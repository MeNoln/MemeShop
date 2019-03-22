using DAL.Interfaces;
using DAL.UoWRepository;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class ServiceNinjectModule : NinjectModule
    {
        private string connection;
        public ServiceNinjectModule(string connection)
        {
            this.connection = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWorkPattern>().To<UnitOfWorkRepository>().WithConstructorArgument(connection);
        }
    }
}
