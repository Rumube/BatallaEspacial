using Ships.CheckLimit;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Vector2 _speed;

        private Ship _ship;
        private Transform _transform;
        private CheckLimits _checkLimits;


        private void Awake()
        {
            _transform = transform;
        }

        public void Configure(Ship ship, CheckLimits checkLimits, Vector2 speed)
        {
            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _transform.Translate(_speed * Time.deltaTime * direction);
            _checkLimits.ClampFinalPosition();
        }
    }
}