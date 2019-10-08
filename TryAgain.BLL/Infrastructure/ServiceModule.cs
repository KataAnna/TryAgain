using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TryAgain.DAL.Interfaces;
using TryAgain.DAL.Repositories;


namespace TryAgain.BLL.Infrastructure
{
    internal class ServiceModule : NinjectModule
    {
        private readonly string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
