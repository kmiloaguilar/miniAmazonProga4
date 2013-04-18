using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MiniAmazon.Data;
using MiniAmazon.Domain;
using Ninject;

namespace MiniAmazon.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        #endregion

        private void AddBindings()
        {
            _kernel.Bind<IRepository>().To<Repository>();
        }
    }
}