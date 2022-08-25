using UnityEngine;
using Zenject;

namespace DevelopmentTools
{
    public static class DiContainerRef
    {
        private static DiContainer _container;
        
        public static DiContainer Container
        {
            get => _container;
            set => _container ??= value;
        }
    }
}
