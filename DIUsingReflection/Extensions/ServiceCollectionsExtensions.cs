using DIUsingReflection.Interfaces;
using System.Reflection;

namespace DIUsingReflection.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            RegisterTransientServices(services, assembly);
            RegisterScopedServices(services, assembly);
            RegisterSingletonServices(services, assembly);
        }
        private static void RegisterTransientServices(IServiceCollection services, Assembly assembly)
        {
            var transientTypes = assembly.GetTypes().Where(t => typeof(ITransient).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var t in transientTypes)
            {
                var transientInterface = t.GetInterfaces().FirstOrDefault(i => i != typeof(ITransient));
                if (transientInterface != null)
                {
                    services.AddTransient(transientInterface, t);
                }
                //services.AddTransient(t.GetInterfaces().FirstOrDefault(i => i != typeof(ITransient)));
            }
        }
        private static void RegisterSingletonServices(IServiceCollection services, Assembly assembly)
        {
            var singletonTypes = assembly.GetTypes().Where(t => typeof(ISingleton).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var s in singletonTypes)
            {
                var singletonInterface = s.GetInterfaces().FirstOrDefault(i => i != typeof(ISingleton));
                if (singletonInterface != null)
                {
                    services.AddTransient(singletonInterface, s);
                }
                //services.AddSingleton(s.GetInterfaces().FirstOrDefault(i => i != typeof(ISingleton)));
            }
        }

        private static void RegisterScopedServices(IServiceCollection services, Assembly assembly)
        {
            var scopedTypes = assembly.GetTypes().Where(t => typeof(IScoped).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var sc in scopedTypes)
            {
                var scopedInterface = sc.GetInterfaces().FirstOrDefault(i => i != typeof(IScoped));
                if (scopedInterface != null)
                {
                    services.AddTransient(scopedInterface, sc);
                }
                //services.AddScoped(sc.GetInterfaces().FirstOrDefault(i => i != typeof(IScoped)));
            }
        }
    }
}
