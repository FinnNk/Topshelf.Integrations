using System.Web.Http;

namespace Sample.Topshelf.WebApi.StructureMap
{
    public class SampleController : ApiController
    {
        private readonly ISampleDependency _dependency;

        public SampleController(ISampleDependency dependency)
        {
            _dependency = dependency;
        }

        public string Get(int id)
        {
            return string.Format("The id squared is: {0}", _dependency.Square(id));
        }
    }
}