using UnityEngine;

namespace Patterns.Mediator
{
    public class Autopilot : MonoBehaviour
    {
        private Vehicle _vehicle;

        public void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
        }
    }
}