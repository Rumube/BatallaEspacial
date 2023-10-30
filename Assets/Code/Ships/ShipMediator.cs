using UnityEngine;
using Inputs;
using Ships.CheckLimit;
using Ships.Weapons;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private ShipId _shipId;
        public string Id => _shipId.Value;
        private Inputs.Input _input;

        public void Configure(Inputs.Input input, CheckLimits checkLimits,
            Vector2 speed, float fireRate, ProjectileId defaultProjectileId)
        {
            _input = input;
            _movementController.Configure(this, checkLimits, speed);
            _weaponController.Configure(this, fireRate, defaultProjectileId);
        }

        private void Update()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }
    }
}
