namespace Sample.Topshelf.WebApi.StructureMap
{
    public class SampleDependency : ISampleDependency
    {
        public int Square(int id)
        {
            return id*id;
        }
    }
}