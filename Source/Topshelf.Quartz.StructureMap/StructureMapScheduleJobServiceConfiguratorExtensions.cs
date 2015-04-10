using System;
using Quartz;
using Topshelf.Logging;
using Topshelf.Quartz.StructureMap.QuartzFactories;
using Topshelf.ServiceConfigurators;
using Topshelf.StructureMap;

namespace Topshelf.Quartz.StructureMap
{
    public static class StructureMapScheduleJobServiceConfiguratorExtensions
    {
        public static ServiceConfigurator<T> UseQuartzStructureMap<T>(this ServiceConfigurator<T> configurator)
            where T : class
        {
            SetupStructureMap();

            return configurator;
        }

        internal static void SetupStructureMap()
        {
            var log = HostLogger.Get(typeof(StructureMapScheduleJobServiceConfiguratorExtensions));

            var container = StructureMapBuilderConfigurator.Container;

            if (container == null)
            {
                throw new Exception("You must call UseStructureMap() to use the Quartz Topshelf StructureMap integration.");
            }

            container.Configure(ctx => ctx.AddRegistry(new QuartzRegistry()));

            Func<IScheduler> schedulerFactory = () => container.GetInstance<IScheduler>();

            ScheduleJobServiceConfiguratorExtensions.SchedulerFactory = schedulerFactory;

            log.Info("[Topshelf.Quartz.StructureMap] Quartz configured to construct jobs with StructureMap.");
        }
    }
}
