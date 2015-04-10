using Topshelf.HostConfigurators;

namespace Topshelf.Quartz.StructureMap
{
    public static class StructureMapScheduleJobHostConfiguratorExtensions
    {
        public static HostConfigurator UseQuartzStructureMap(this HostConfigurator configurator)
        {
            StructureMapScheduleJobServiceConfiguratorExtensions.SetupStructureMap();

            return configurator;
        }
    }
}