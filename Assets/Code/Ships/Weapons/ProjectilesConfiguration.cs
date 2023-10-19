using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ships.Weapons.Projectiles;


namespace Ships.Weapons
{
    [CreateAssetMenu(menuName = "Create ProjectilesConfiguration", fileName = "ProjectilesConfiguration", order = 1)]
    public class ProjectilesConfiguration : ScriptableObject
    {
        [SerializeField] private Projectile[] _projectilePrefabs;
        private Dictionary<string, Projectile> _idToProjectilePrefab;

        private void Awake()
        {
            _idToProjectilePrefab = new Dictionary<string, Projectile>();

            foreach (var projectile in _projectilePrefabs)
            {
                _idToProjectilePrefab.Add(projectile.Id, projectile);
            }
        }

        public Projectile GetProjectibleById(string id)
        {
            if (!_idToProjectilePrefab.TryGetValue(id, out var projectile))
            {
                throw new System.Exception($"Projectile {id} not found");
            }
            return projectile;
        }
    }
}


