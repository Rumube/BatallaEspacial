using Common;
using Ships.Common;
using UnityEngine;
using Patterns.ServiceLocator;

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

        private CheckDestroyLimits.CheckDestroyLimits _checkDestryoLimits;
        public string Id => _shipId.Value;
        private Inputs.Input _input;
        private Teams _team;
        private int _score;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();

            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.Restart, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();

            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.Restart, this);
        }

        public void Configure(ShipConfiguration configuration)
        {
            _checkDestryoLimits = configuration.CheckDestroyLimits;
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
            CheckDestroyLimits();
        }

        private void CheckDestroyLimits()
        {
            if (_checkDestryoLimits.IsInsideTheLimits(transform.position))
            {
                return;
            }

            Destroy(gameObject);

            var shipDestroyedEventData = new ShipDestroyedEventData(0, _team, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(shipDestroyedEventData);
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
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(shipDestroyedEventData);
            }
        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId != EventIds.GameOver 
            && eventData.EventId != EventIds.Victory
            && eventData.EventId != EventIds.Restart)
            {
                return;
            }

            _weaponController.Restart();
            Destroy(gameObject);
        }
    }
}
