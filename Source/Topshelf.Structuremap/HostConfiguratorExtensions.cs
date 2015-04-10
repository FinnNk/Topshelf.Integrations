using StructureMap.Configuration.DSL;
using Topshelf.HostConfigurators;
using Topshelf.Logging;

namespace Topshelf.StructureMap
{
    public static class HostConfiguratorExtensions
    {
        public static HostConfigurator UseStructureMap(this HostConfigurator configurator, params Registry[] registries)
        {
            var log = HostLogger.Get(typeof(HostConfiguratorExtensions));

            log.Info("[Topshelf.StructureMap] Integration Started in host.");
            log.Debug(string.Format("StructureMap container instantiated with {0} registries.", registries.Length));

            configurator.AddConfigurator(new StructureMapBuilderConfigurator(registries));
            return configurator;
        }
    }
}