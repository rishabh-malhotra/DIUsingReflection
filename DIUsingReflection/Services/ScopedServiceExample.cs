using DIUsingReflection.Interfaces;

namespace ServiceRegistrationUsingReflection.Services
{
    public class ScopedServiceExample:IScoped, IScopedExample
    {
        public Guid ScopedGuid { get; set; }
        public ScopedServiceExample()
        {
             ScopedGuid =  Guid.NewGuid();
        }
        public Guid DoScopedWork()
        {
           return ScopedGuid;
        }
    }
}
