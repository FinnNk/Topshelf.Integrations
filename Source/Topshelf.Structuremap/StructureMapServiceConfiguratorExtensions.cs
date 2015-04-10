using Topshelf.Logging;
using Topshelf.ServiceConfigurators;

namespace Topshelf.StructureMap
{
    public static class StructureMapServiceConfiguratorExtensions
    {
        public static ServiceConfigurator<T> ConstructUsingStructureMap<T>(this ServiceConfigurator<T> configurator) where T : class
        {
            var log = HostLogger.Get(typeof(HostConfiguratorExtensions));

            log.Info("[Topshelf.StructureMap] Service configured to construct using StructureMap.");

            configurator.ConstructUsing(serviceFactory => StructureMapBuilderConfigurator.Container.GetInstance<T>());

            return configurator;
        }
    }
}