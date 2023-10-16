using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _configuration;

        public ProjectileFactory(ProjectilesConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Projectile Create (string id, Vector3 position, Quaternion rotation)
        {
            var prefab = _configuration.GetProjectibleById(id);

            return Object.Instantiate(prefab, position, rotation);
        }
    }
}

