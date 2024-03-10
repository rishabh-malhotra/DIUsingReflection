using DIUsingReflection.Interfaces;

namespace DIUsingReflection.Services
{
    public class SingletonServiceExample2 : ISingleton, ISingletonExample2
    {
        public Guid SingletonGuid2 { get; set; }
        public SingletonServiceExample2()
        {
            SingletonGuid2 = Guid.NewGuid();
        }
        public Guid DoSingletonWorkAgain()
        {
            return SingletonGuid2;
        }
    }
}
