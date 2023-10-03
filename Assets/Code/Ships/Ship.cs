using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Joystick _joystick;
        private Transform _transform;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _transform = transform;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _transform.Translate(_speed * Time.deltaTime * direction);
            ClampFinalPosition();
        }

        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0.03f, 0.97f);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.03f, 0.97f);
            _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private Vector2 GetDirection()
        {
            //var horizontalDir = Input.GetAxis("Horizontal");
            //var verticalDir = Input.GetAxis("Vertical");
            //return new Vector2(horizontalDir, verticalDir);

            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }
    }
}
