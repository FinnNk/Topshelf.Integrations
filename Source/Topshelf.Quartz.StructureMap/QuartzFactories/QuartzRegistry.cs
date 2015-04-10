using Quartz;
using StructureMap.Configuration.DSL;

namespace Topshelf.Quartz.StructureMap.QuartzFactories
{
    public class QuartzRegistry : Registry
    {
        public QuartzRegistry()
        {
            For<ISchedulerFactory>().Use<StructureMapSchedulerFactory>();
            For<IScheduler>().Use(ctx => ctx.GetInstance<ISchedulerFactory>().GetScheduler()); 
        }
    }
}