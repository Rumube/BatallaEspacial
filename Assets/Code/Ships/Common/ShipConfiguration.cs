using Ships.CheckLimit;
using Ships.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Common
{
    public class ShipConfiguration : MonoBehaviour
    {
        public readonly Inputs.Input Input;
        public readonly CheckLimits CheckLimits;
        public readonly Vector2 Speed;
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectileId;

        public ShipConfiguration(Inputs.Input input, CheckLimits checkLimits, Vector2 speed, float fireRate, ProjectileId defaultProjectileId)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
        }
    }
}

