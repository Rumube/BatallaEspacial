using UnityEngine;

namespace Patterns.Mediator
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField] private Wheel[] _wheels;
        private Vehicle _vehicle;

        public void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void AddFriccion()
        {

        }

        public void RemoveFriction()
        {

        }

        public void TurnLeft()
        {

        }

        public void TurnRight()
        {

        }
    }
}