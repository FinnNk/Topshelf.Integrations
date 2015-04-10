using System;
using Quartz;
using StructureMap.Configuration.DSL;
using Topshelf;
using Topshelf.Quartz;
using Topshelf.Quartz.StructureMap;
using Topshelf.Quartz.StructureMap.QuartzFactories;
using Topshelf.StructureMap;

namespace Sample.Topshelf.Quartz.StructureMap.JobAsService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                // Topshelf.Ninject (Optional) - Initiates Ninject and consumes Modules
                c.UseStructureMap(new SampleRegistry());
                // Topshelf.Quartz.Ninject (Optional) - Construct IJob instance with Ninject
                c.UseQuartzStructureMap();

                c.ScheduleQuartzJobAsService(q =>
                        q.WithJob(() =>
                            JobBuilder.Create<SampleJob>().Build())
                        .AddTrigger(() =>
                            TriggerBuilder.Create()
                                .WithSimpleSchedule(builder => builder
                                    .WithIntervalInSeconds(5)
                                    .RepeatForever())
                                .Build())
                                    );
            });

        }
    }

    public class SampleJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("The current time is: {0}", DateTime.Now);
        }
    }

    public class SampleRegistry : Registry
    {
    }
}
