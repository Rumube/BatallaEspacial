using Ships.CheckLimit;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Vector2 _speed;

        private Ship _ship;
        private Rigidbody2D _rigidbody;
        private CheckLimits _checkLimits;
        private Vector2 _currentPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _currentPosition = _rigidbody.position;
        }

        public void Configure(Ship ship, CheckLimits checkLimits, Vector2 speed)
        {
            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _currentPosition += (_speed * Time.deltaTime * direction);
            _currentPosition = _checkLimits.ClampFinalPosition(_currentPosition);
            _rigidbody.MovePosition(_currentPosition);
        }
    }
}