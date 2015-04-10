using StructureMap.Configuration.DSL;

namespace Sample.Topshelf.WebApi.StructureMap
{
    public class SampleRegistry : Registry
    {
        public SampleRegistry()
        {
            For<ISampleDependency>().Use<SampleDependency>();
        }
    }
}