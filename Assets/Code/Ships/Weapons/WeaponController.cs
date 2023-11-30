using Ships.Common;
using Ships.Weapons;
using Ships.Weapons.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ships
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectileConfiguration;
        [SerializeField] private Transform _projectileSpawnerPosition;
        private float _fireRateInSeconds;
        private Teams _team;
        private float _remainingSecondsToBeAbleShoot;
        private ProjectileFactory _projectileFactory;

        private string _activeProjectileId;
        private Ship _ship;
        private List<Projectile> _aliveProjectiles;


        private void Awake()
        {
            _projectileFactory = new ProjectileFactory(Instantiate(_projectileConfiguration));
            _aliveProjectiles = new List<Projectile>();
        }

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId, Teams team)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;
            _team = team;
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
                                                        _projectileSpawnerPosition.rotation,
                                                        _team);
            _aliveProjectiles.Add(projectile);
            projectile.OnDestroy += OnProjectileDestroy;
            _remainingSecondsToBeAbleShoot = _fireRateInSeconds;
        }

        private void OnProjectileDestroy(Projectile projectile)
        {
            _aliveProjectiles.Remove(projectile);
            projectile.OnDestroy -= OnProjectileDestroy;
        }

        public void Restart()
        {
            foreach (var projectile in _aliveProjectiles)
            {
                Destroy(projectile.gameObject);
            }

            _aliveProjectiles.Clear();
        }
    }
}