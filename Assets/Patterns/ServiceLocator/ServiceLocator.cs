using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Patterns.ServiceLocator
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());
        private static ServiceLocator _instance;

        private readonly Dictionary<Type, object> _services;

        private ServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }

        public void RegisterService<T>(T service)
        {
            var type = typeof(T);
            Assert.IsFalse(_services.ContainsKey(type),
                           $"Service {type} akready regustered");
            _services.Add(type, service);
        }

        public T GetService<T>()
        {
            var type = typeof(T);
            if (!_services.TryGetValue(type, out var service))
            {
                throw new Exception($"Service {type} not found");
            }
            return (T)service;
        }

        public bool Contains<T>()
        {
            var type = typeof(T);
            return _services.ContainsKey(type);
        }
    }
}