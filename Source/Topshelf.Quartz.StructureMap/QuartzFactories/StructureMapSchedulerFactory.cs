// Ninject.Extensions.Quartz
// https://github.com/dtinteractive/Ninject.Extensions.Quartz
// 
// Copyright (c) 2013 DealerTrack Interactive
// Licensed under the MIT license.

using Quartz;
using Quartz.Impl;

namespace Topshelf.Quartz.StructureMap.QuartzFactories
{
	public class StructureMapSchedulerFactory : StdSchedulerFactory
	{
		private readonly StructureMapJobFactory _structureMapJobFactory;

		public StructureMapSchedulerFactory(StructureMapJobFactory structureMapJobFactory)
		{
			_structureMapJobFactory = structureMapJobFactory;
		}

		protected override IScheduler Instantiate(global::Quartz.Core.QuartzSchedulerResources rsrcs, global::Quartz.Core.QuartzScheduler qs)
		{
			qs.JobFactory = _structureMapJobFactory;
			return base.Instantiate(rsrcs, qs);
		}
	}
}