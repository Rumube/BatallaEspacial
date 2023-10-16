using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Factory
{
    [CreateAssetMenu(menuName ="Factory/Create EnemiesConfiguration", fileName ="EnemiesConfiguration", order = 1)]
    public class EnemiesConfiguration : ScriptableObject
    {
        [SerializeField] private Enemy[] _enemyPrefabs;
        private Dictionary<string, Enemy> _idToEnemyPrefab;

        private void Awake()
        {
            _idToEnemyPrefab = new Dictionary<string, Enemy>();

            foreach (Enemy enemyPrefab in _enemyPrefabs)
            {
                _idToEnemyPrefab.Add(enemyPrefab.Id, enemyPrefab);
            }
        }

        public Enemy GetEnemyById(string id)
        {
            return _idToEnemyPrefab[id];
        }
    }
}


