using System.Collections.Generic;
using System.Diagnostics;

namespace Helpers
{
    public class ServiceSingleton
    {
        private const string MessageHeader = "[ServiceSingleton]";

        private static ServiceSingleton _instance;
        public static ServiceSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    new ServiceSingleton();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

#pragma warning disable UAC1009 // Unsupported collection type for serialization
        public Dictionary<string, object> servicesDict;
#pragma warning restore UAC1009 // Unsupported collection type for serialization

        public ServiceSingleton()
        {
            if(_instance != null)
            {
                throw new System.Exception($"{MessageHeader} There can be only ONE ServiceSingleton instance");
            }

            Instance = this;
            servicesDict = new();
        }

        ~ServiceSingleton()
        {
            Instance = null;

            servicesDict.Clear();
            servicesDict = null;
        }

        public static void Add<T>(T serviceObject)
        {
            string serviceName = serviceObject.GetType().Name;
            Instance.servicesDict.Add(serviceName, serviceObject);

            UnityEngine.Debug.Log($"{MessageHeader} {serviceName} added");
        }

        public static T Get<T>()
        {
            string typeName = typeof(T).Name;
            if (!Instance.servicesDict.TryGetValue(typeName, out object value))
            {
                throw new System.Exception($"{MessageHeader} ServiceSingleton.Get(\"{typeName}\") is NOT listed");
            }
            return (T) value;
        }
    }
}
