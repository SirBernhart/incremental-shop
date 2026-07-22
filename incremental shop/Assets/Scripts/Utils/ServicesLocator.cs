using System;
using System.Collections.Generic;

namespace Utils
{
    public static class ServicesLocator
    {
        private static Dictionary<Type, object> registeredServices = new();

        public static void Register(object service)
        {
            if(service == null)
            {
                UnityEngine.Debug.LogError("ServicesLocator.Register - couldn't Register a null object");
                return;
            }

            Register(service.GetType(), service);
        }

        public static void Register<T>(object service)
        {
            Register(typeof(T), service);
        }

        public static void Unregister<T>()
        {
            registeredServices.Remove(typeof(T));
        }

        public static T Get<T>()
        {
            return (T) registeredServices[typeof(T)];
        }

        private static void Register(Type expectedType, object service)
        {
            registeredServices.TryAdd(expectedType, service);
        }
    }
}