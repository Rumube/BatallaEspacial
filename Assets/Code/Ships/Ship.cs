using UnityEngine;
using Inputs;
using Ships.CheckLimit;
using Ships.Weapons;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnerPosition;

        private Inputs.Input _input;
        private Transform _transform;
        private CheckLimits _checkLimits;
        private float _remainingSecondsToBeAbleShoot;


        private void Awake()
        {
            _transform = transform;
        }

        public void Configure(Inputs.Input input, CheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            _remainingSecondsToBeAbleShoot -= Time.deltaTime;
            if(_remainingSecondsToBeAbleShoot > 0)
            {
                return;
            }
            if (_input.IsFireActionPressed())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleShoot = _fireRateInSeconds;
            Instantiate(_projectilePrefab, _projectileSpawnerPosition.position, _projectileSpawnerPosition.rotation);
        }

        private void Move(Vector2 direction)
        {
            _transform.Translate(_speed * Time.deltaTime * direction);
            _checkLimits.ClampFinalPosition();
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}
