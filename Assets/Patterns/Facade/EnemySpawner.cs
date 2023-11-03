using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Facade
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<Enemy> Enemies = new()
        {
            new Enemy(50, 50),
            new Enemy(50, 50)
        };
    }
}

