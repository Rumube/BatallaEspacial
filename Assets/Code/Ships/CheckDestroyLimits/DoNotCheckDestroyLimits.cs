using UnityEngine;

namespace Ships.CheckDestroyLimits
{
    public class DoNotCheckDestroyLimits : CheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position)
        {
            return true;
        }
    }
}