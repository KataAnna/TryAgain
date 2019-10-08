using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryAgain.BLL.Interfaces;
using TryAgain.BLL.Services;

namespace TryAgain.Util
{
    public class ProjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectService>().To<OrderService>();
        }
    }
}
