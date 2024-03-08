using DIUsingReflection.Interfaces;

namespace DIUsingReflection.Services
{
    public class SingletonServiceExample : ISingleton, ISingletonExample
    {
        public Guid SingletonGuid { get; set; }
        public SingletonServiceExample()
        {
            SingletonGuid = Guid.NewGuid();
        }
        public Guid DoSingletonWork()
        {
            return SingletonGuid;
        }
    }
}
