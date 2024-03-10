using DIUsingReflection.Interfaces;

namespace ServiceRegistrationUsingReflection.Services
{
    public class TransientServiceExample2: ITransient, ITransientExample2
    {
        Guid TransientGuid2 { get; set; }
        public TransientServiceExample2()
        {
            TransientGuid2 = Guid.NewGuid();
        }
        public Guid DoTransientWorkAgain()
        {
            return TransientGuid2;
        }
    }
}
