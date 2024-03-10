using DIUsingReflection.Interfaces;

namespace ServiceRegistrationUsingReflection.Services
{
    public class ScopedServiceExample2 : IScoped, IScopedExample2
    {
        public Guid ScopedGuid2 { get; set; }
        public ScopedServiceExample2()
        {
            ScopedGuid2 = Guid.NewGuid();
        }
        public Guid DoScopedWorkAgain()
        {
            return ScopedGuid2;
        }
    }
}
