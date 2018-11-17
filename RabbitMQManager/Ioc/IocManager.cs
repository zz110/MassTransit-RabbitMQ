using System;
using System.Diagnostics;

namespace RabbitMQManager
{
    public class IocManager
    {
        private static UnityDependencyResolver _resolver;

        public static void Initialize(UnityDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(Type type)
        {
            return (T)_resolver.Resolve<T>(type);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(Type type, string name)
        {
            return (T)_resolver.Resolve<T>(type, name);
        }

        [DebuggerStepThrough]
        public static T Resolve<T>()
        {
            return _resolver.Resolve<T>();
        }

        [DebuggerStepThrough]
        public static T Resolve<T>(string name)
        {
            return _resolver.Resolve<T>(name);
        }

        [DebuggerStepThrough]
        public static void Dispose()
        {
            _resolver.Shutdown();
        }
    }
}
