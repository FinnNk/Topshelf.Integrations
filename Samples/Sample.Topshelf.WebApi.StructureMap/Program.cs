using System.Web.Http;
using Topshelf;
using Topshelf.StructureMap;
using Topshelf.WebApi;
using Topshelf.WebApi.StructureMap;

namespace Sample.Topshelf.WebApi.StructureMap
{
    class Program
    {
        static void Main()
        {
            HostFactory.Run(c =>
            {
                c.UseStructureMap(new SampleRegistry()); //Initiates StructureMap and adds configuration

                c.Service<SampleService>(s =>
                {
                    //Specifies that Topshelf should delegate to StructureMap for construction
                    s.ConstructUsingStructureMap();

                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());

                    //Topshelf.WebApi - Begins configuration of an endpoint
                    s.WebApiEndpoint(api => 
                        //Topshelf.WebApi - Uses localhost as the domain, defaults to port 8080.
                        //You may also use .OnHost() and specify an alternate port.
                        api.OnLocalhost()
                            //Topshelf.WebApi - Pass a delegate to configure your routes
                            .ConfigureRoutes(Configure)
                            //Topshelf.WebApi.StructureMap (Optional) - You may delegate controller 
                            //instantiation to StructureMap.
                            //Alternatively you can set the WebAPI Dependency Resolver with
                            //.UseDependencyResolver()
                            .UseStructureMapDependencyResolver()
                            //Instantaties and starts the WebAPI Thread.
                            .Build());
                });
            });
        }

        private static void Configure(HttpRouteCollection routes)
        {
            routes.MapHttpRoute(
                    "DefaultApiWithId", 
                    "Api/{controller}/{id}", 
                    new { id = RouteParameter.Optional }, 
                    new { id = @"\d+" });
        }
    }
}
