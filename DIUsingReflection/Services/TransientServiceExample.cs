using DIUsingReflection.Interfaces;

namespace ServiceRegistrationUsingReflection.Services
{
    public class TransientServiceExample: ITransient, ITransientExample
    {
        Guid TransientGuid { get; set; }
        public TransientServiceExample()
        {
            TransientGuid = Guid.NewGuid();
        }
        public Guid DoTransientWork()
        {
            return TransientGuid;
        }
    }
}
