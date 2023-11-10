using UnityEngine;

namespace Ships.CheckDestroyLimits
{
    public interface CheckDestroyLimits
    {
        bool IsInsideTheLimits(Vector3 position);
    }
}