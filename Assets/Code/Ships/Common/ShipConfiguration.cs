using Ships.CheckLimit;
using Ships.Weapons;
using UnityEngine;

namespace Ships.Common
{
    public class ShipConfiguration : MonoBehaviour
    {
        public readonly Inputs.Input Input;
        public readonly CheckLimits CheckLimits;
        public readonly CheckDestroyLimits.CheckDestroyLimits CheckDestroyLimits;

        public readonly Vector2 Speed;
        public readonly int Health;
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectileId;
        public readonly Teams Team;
        public readonly int Score;

        public ShipConfiguration(Inputs.Input input, CheckLimits checkLimits, Vector2 speed,
                                 int health, float fireRate, ProjectileId defaultProjectileId,
                                 Teams team, int score, CheckDestroyLimits.CheckDestroyLimits checkDestroyLimits)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            Health = health;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
            Team = team;
            Score = score;
            CheckDestroyLimits = checkDestroyLimits;
        }
    }
}

