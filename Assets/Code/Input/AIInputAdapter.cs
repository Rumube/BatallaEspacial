using UnityEngine;

namespace Ships
{
    public class AIInputAdapter : Input
    {
        private readonly Ship _ship;
        private int _currentDirectionX;
        private Camera _camera;

        public AIInputAdapter(Ship ship)
        {
            _ship = ship;
            _currentDirectionX = 1;
            _camera = Camera.main;
        }

        public Vector2 GetDirection()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_ship.transform.position);

            if(viewportPoint.x < 0.05f)
            {
                _currentDirectionX = 1;
            }else if(viewportPoint.x > 0.95f)
            {
                _currentDirectionX = -1;
            }

            return new Vector2(_currentDirectionX, -0.1f);
        }
    }
}