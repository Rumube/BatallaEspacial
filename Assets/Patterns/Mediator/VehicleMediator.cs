using UnityEngine;
namespace Patterns.Mediator
{
    public class VehicleMediator : MonoBehaviour, Vehicle
    {
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _lights;
        [SerializeField] private SteeringWheel _steeringWheel;
        [SerializeField] private Brake _brake;
        [SerializeField] private Autopilot _autopilot;

        private void Awake()
        {
            _brake.Configure(this);
            _steeringWheel.Configure(this);
            _autopilot.Configure(this);

            foreach (var wheel in _wheels)
            {
                wheel.Configure(this);
            }
            foreach (var light in _lights)
            {
                light.Configure(this);
            }
        }

        public void BrakePressed()
        {
            foreach (Wheel wheel in _wheels)
            {
                wheel.AddFriccion();
            }

            foreach (VehicleLight light in _lights)
            {
                light.TurnOn();
            }
        }

        public void BrakeRelease()
        {
            foreach (Wheel wheel in _wheels)
            {
                wheel.RemoveFriction();
            }

            foreach (VehicleLight light in _lights)
            {
                light.TurnOff();
            }
        }

        public void LeftPressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnLeft();
            }
        }

        public void RightPressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnRight();
            }
        }

        public void ObstacleDetected()
        {
            BrakePressed();
        }
    }
}