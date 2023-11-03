using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Facade
{
    public class Player : Hero
    {
        public int Mana;

        public Player(int health, int mana) : base(health)
        {
            Mana = mana;
        }
    }
}

