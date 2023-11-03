using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Facade
{
    [Serializable]
    public class SaveData
    {
        public List<Enemy> Enemies;
        public Player Player;

        public SaveData(List<Enemy> enemies, Player player)
        {
            Enemies = enemies;
            Player = player;
        }
    }
}

