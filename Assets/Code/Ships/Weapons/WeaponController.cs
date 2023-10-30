using Ships.Weapons;
using System;
using System.Linq;
using UnityEngine;

namespace Ships
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectileConfiguration;
        [SerializeField] private Transform _projectileSpawnerPosition;
        private float _fireRateInSeconds;
        private float _remainingSecondsToBeAbleShoot;
        private ProjectileFactory _projectileFactory;

        private string _activeProjectileId;
        private Ship _ship;


        private void Awake()
        {
            _projectileFactory = new ProjectileFactory(Instantiate(_projectileConfiguration));   
        }

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;
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