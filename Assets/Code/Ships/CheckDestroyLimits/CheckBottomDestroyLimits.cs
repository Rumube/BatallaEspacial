using UnityEngine;

namespace Ships.CheckDestroyLimits
{
    public class CheckBottomDestroyLimits : CheckDestroyLimits
    {
        private Camera _camera;
        public CheckBottomDestroyLimits(Camera camera)
        {
            _camera = camera;
        }

        public bool IsInsideTheLimits(Vector3 position)
        {
            var viewportPoint = _camera.WorldToViewportPoint(position);
            return viewportPoint.y > 0;
        }
    }
}