using Common;
using Ships.Common;
using UI;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship, EventObserver
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private ShipId _shipId;
        [SerializeField] private HealthController _healthController;

        public string Id => _shipId.Value;
        private Inputs.Input _input;
        private Teams _team;
        private int _score;

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.GameOver, this);
        }

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
                Destroy(gameObject);

                var shipDestroyedEventData = new ShipDestroyedEventData(_score, _team, GetInstanceID());
                EventQueue.Instance.EnqueueEvent(shipDestroyedEventData);
            }
        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId != EventIds.GameOver)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}
