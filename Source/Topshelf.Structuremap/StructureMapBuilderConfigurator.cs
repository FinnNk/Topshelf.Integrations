using System.Collections.Generic;
using StructureMap;
using StructureMap.Configuration.DSL;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.StructureMap
{
    public class StructureMapBuilderConfigurator : HostBuilderConfigurator
    {
        private static Registry[] _modules;
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new Container();

                    foreach (var registry in _modules)
                    {
                        var reg = registry;
                        _container.Configure(x => x.AddRegistry(reg));
                    }
                }

                return _container;
                
            }
        }

        public StructureMapBuilderConfigurator(Registry[] modules)
        {
            _modules = modules;
        }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }

        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }
    }
}