using System;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useJoystick;
        [SerializeField] private bool _useAI;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.Configure(GetInput(), GetCheckLimitsStrategy());
        }

        private CheckLimits GetCheckLimitsStrategy()
        {
            if (_useAI)
            {
                return new InitialPositionCheckLimits(_ship.transform, 10f);
            }
            return new ViewportCheckLimits(_ship.transform, Camera.main);
        }

        private Input GetInput()
        {
            if(_useAI)
            {
                return new AIInputAdapter(_ship);
            }
            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick);
            }
            Destroy(_joystick.gameObject);
            return new UnityInputAdapter();
        }
    }
}