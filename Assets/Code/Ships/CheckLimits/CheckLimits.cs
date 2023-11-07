
using UnityEngine;

namespace Ships.CheckLimit
{
    public interface CheckLimits
    {
        Vector2 ClampFinalPosition(Vector2 _currentPosition);
    }
}