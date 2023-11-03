using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Facade
{
    public class Enemy : Hero
    {
        public int Stamina;

        public Enemy(int health, int stamina) : base(health)
        {
            Stamina = stamina;
        }
    }
}

