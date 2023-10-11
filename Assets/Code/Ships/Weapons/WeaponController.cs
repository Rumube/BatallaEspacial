using Ships.Weapons;
using System;
using System.Linq;
using UnityEngine;

namespace Ships
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile[] _projectilePrefabs;
        [SerializeField] private Transform _projectileSpawnerPosition;
        private float _remainingSecondsToBeAbleShoot;

        private string _activeProjectileId;
        private Ship _ship;


        public void Configure(Ship ship)
        {
            _ship = ship;
            _activeProjectileId = "Projectil1";
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
            var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(_activeProjectileId));
            _remainingSecondsToBeAbleShoot = _fireRateInSeconds;
            Instantiate(prefab, _projectileSpawnerPosition.position, _projectileSpawnerPosition.rotation);
        }
    }
}