using Ships.Common;
using Ships.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour, Damageable
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] protected Rigidbody2D _rigidbody2D;

        public Teams Team { get; private set; }
        protected Transform _transform;
        public string Id => _id.Value;

        public Action<Projectile> OnDestroy;


        public void Configure(Teams team)
        {
            Team = team;
        }

        private void Start()
        {
            _transform = transform;
            DoStart();
            StartCoroutine(DestroyIn(5f));
        }

        protected abstract void DoStart();

        private void FixedUpdate()
        {
            DoMove();
        }

        protected abstract void DoMove();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.GetComponent<Damageable>();
            if(damageable.Team ==  Team)
            {
                return;
            }
            damageable.AddDamage(1);
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        protected abstract void DoDestroy();

        private void DestroyProjectile()
        {
            DoDestroy();
            OnDestroy?.Invoke(this);
            Destroy(gameObject);
        }

        public void AddDamage(int amount)
        {
            DestroyProjectile();
        }
    }
}
