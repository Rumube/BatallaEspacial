using Inputs;
using Ships.CheckLimit;
using Ships.Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

namespace Ships.Common
{
    public class ShipBuilder
    {
        public enum InputMode
        {
            Unity,
            Joystick,
            Ai
        }

        public enum CheckLimitsTypes
        {
            InitialPosition,
            ViewPort
        }

        private ShipToSpawnConfiguration _shipConfiguration;

        private ShipMediator _prefab;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private Inputs.Input _input;
        private CheckLimits _checkLimits;
        private InputMode _inputMode;
        private Joystick _joystick;
        private JoyButton _joyButton;
        private CheckLimitsTypes _checkLitmitsType;
        private Teams _team;

        public ShipBuilder FromPrefab(ShipMediator prefab)
        {
            _prefab = prefab;
            return this;
        }

        public ShipBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }
        public ShipBuilder WithTeam(Teams team)
        {
            _team = team;
            return this;
        }

        public ShipBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public ShipBuilder WithInput(Inputs.Input input)
        {
            _input = input;
            return this;
        }

        public ShipBuilder WithCheckLimits(CheckLimits checkLimits)
        {
            _checkLimits = checkLimits;
            return this;
        }
        public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipToSpawnConfiguration)
        {
            _shipConfiguration = shipToSpawnConfiguration;
            return this;
        }

        public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton;
            return this;
        }

        public ShipBuilder WithInputMode(InputMode inputMode)
        {
            _inputMode = inputMode;
            return this;
        } 

        public ShipBuilder WithCheckLimitsType(CheckLimitsTypes type)
        {
            _checkLitmitsType = type;
            return this;
        }

        public ShipMediator Build()
        {
            var ship = Object.Instantiate(_prefab, _position, _rotation);
            var configuration = new ShipConfiguration(GetInput(ship),
                                                      GetCheckLimits(ship),
                                                      _shipConfiguration.Speed,
                                                      _shipConfiguration.Health,
                                                      _shipConfiguration.FireRate,
                                                      _shipConfiguration.DefaultProjectileId,
                                                      _team,
                                                      _shipConfiguration.Score);
            
            ship.Configure(configuration);
            return ship;
        }

        private CheckLimits GetCheckLimits(ShipMediator ship)
        {
            if(_checkLimits != null)
            {
                return _checkLimits;
            }

            switch (_checkLitmitsType)
            {
                case CheckLimitsTypes.InitialPosition:
                    return new InitialPositionCheckLimits(ship.transform, 10);
                case CheckLimitsTypes.ViewPort:
                    return new ViewportCheckLimits(Camera.main);
                default:
                    return null;
            }
        }

        private Inputs.Input GetInput(ShipMediator shipMediator)
        {
            if(_input != null)
            {
                return _input;
            }

            switch (_inputMode)
            {
                case InputMode.Unity:
                    return new UnityInputAdapter();
                case InputMode.Joystick:
                    Assert.IsNotNull(_joystick);
                    Assert.IsNotNull(_joyButton);
                    return new JoystickInputAdapter(_joystick, _joyButton);
                case InputMode.Ai:
                    return new AIInputAdapter(shipMediator);
                default: return null;
            }
        }
    }
}


