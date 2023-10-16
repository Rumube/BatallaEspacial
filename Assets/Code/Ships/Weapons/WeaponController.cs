using Ships.Weapons;
using System;
using System.Linq;
using UnityEngine;

namespace Ships
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectileConfiguration;
        [SerializeField] private ProjectileId _defaultProjectileId;
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Transform _projectileSpawnerPosition;
        private float _remainingSecondsToBeAbleShoot;
        private ProjectileFactory _projectileFactory;

        private string _activeProjectileId;
        private Ship _ship;


        private void Awake()
        {
            _projectileFactory = new ProjectileFactory(Instantiate(_projectileConfiguration));   
        }

        public void Configure(Ship ship)
        {
            _ship = ship;
            _activeProjectileId = _defaultProjectileId.Value;
        }

        internal void TryShoot()
        {
            _remainingSecondsToBeAbleShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleShoot > 0)
            {
                return;
            }
            Shoot();
        }

        private void Shoot()
        {
            var projectile = _projectileFactory.Create( _activeProjectileId,
                                                        _projectileSpawnerPosition.position,
                                                        _projectileSpawnerPosition.rotation);
            _remainingSecondsToBeAbleShoot = _fireRateInSeconds;
        }
    }
}