using Patterns.ServiceLocator;
using UnityEngine;

namespace Core
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(ServiceLocator serviceLocator);
    }
}