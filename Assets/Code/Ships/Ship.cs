using UnityEngine;
using Inputs;
using Ships.CheckLimit;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Inputs.Input _input;
        private Transform _transform;
        private CheckLimits _checkLimits;

        private void Awake()
        {
            _transform = transform;
        }

        public void Configure(Inputs.Input input, CheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _transform.Translate(_speed * Time.deltaTime * direction);
            _checkLimits.ClampFinalPosition();
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}
