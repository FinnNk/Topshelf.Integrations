using System;
using StructureMap;
using Topshelf.Logging;
using Topshelf.StructureMap;

namespace Topshelf.WebApi.StructureMap
{
    public static class StructureMapWebApiServiceConfiguratorExtensions
    {
        public static WebApiConfigurator UseStructureMapDependencyResolver(this WebApiConfigurator configurator)
        {
            var log = HostLogger.Get(typeof(StructureMapWebApiServiceConfiguratorExtensions));
            
            IContainer container = StructureMapBuilderConfigurator.Container;

            if (container == null)
            {
                throw new Exception("You must call UseStructureMap() to use the WebApi Topshelf StructureMap integration.");
            }

            configurator.UseDependencyResolver(new StructureMapDependencyResolver(container));

            log.Info("[Topshelf.WebApi.StructureMap] WebAPI Dependency Resolver configured to use StructureMap.");

            return configurator;
        }
    }
}