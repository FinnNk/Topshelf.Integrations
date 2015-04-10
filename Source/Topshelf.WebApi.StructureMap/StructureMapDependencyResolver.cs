using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace Topshelf.WebApi.StructureMap
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        protected IContainer Container;

        public StructureMapDependencyResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        public IDependencyScope BeginScope()
        {
            var nestedContainer = Container.GetNestedContainer();
            return new StructureMapDependencyResolver(nestedContainer);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetAllInstances(serviceType).Cast<object>();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return Container.TryGetInstance(serviceType);
                }

                return Container.GetInstance(serviceType);
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("Could not active service type: {0}", serviceType.Name), exception);
            }
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}