using Ships.Common;
using UI;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private ShipId _shipId;
        [SerializeField] private HealthController _healthController;

        public string Id => _shipId.Value;
        private Inputs.Input _input;
        private Teams _team;
        private int _score;

        public void Configure(ShipConfiguration configuration)
        {
            _input = configuration.Input;
            _movementController.Configure(this, configuration.CheckLimits, configuration.Speed);
            _weaponController.Configure(this, configuration.FireRate, configuration.DefaultProjectileId, configuration.Team);
            _healthController.Configure(this, configuration.Health, configuration.Team);
            _team = configuration.Team;
            _score = configuration.Score;
        }

        private void FixedUpdate()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
        }

        private void Update()
        {
            TryShoot();
        }

        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.GetComponent<Damageable>();
            if(damageable.Team == _team)
            {
                return;
            }
            damageable.AddDamage(1);
        }

        public void OnDamageRecived(bool isDeath)
        {
            if(isDeath)
            {
                var scoreView = FindObjectOfType<ScoreView>();
                scoreView.AddScore(_team, _score);
                Destroy(gameObject);
            }
        }
    }
}
