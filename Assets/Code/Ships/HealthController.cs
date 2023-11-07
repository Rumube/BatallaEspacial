using Ships.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public class HealthController : MonoBehaviour, Damageable
    {
        private int _health;
        private Ship _ship;

        public Teams Team { get; private set; }

        public void Configure(Ship ship, int health, Teams team)
        {
            _ship = ship;
            _health = health;
            Team = team;
        }


        public void AddDamage(int amount)
        {
            _health = Mathf.Max(0, _health - amount);
            var isDeath = _health <= 0;
            _ship.OnDamageRecived(isDeath);
        }
    }
}


