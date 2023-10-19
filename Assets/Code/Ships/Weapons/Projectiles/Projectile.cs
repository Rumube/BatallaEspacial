using Ships.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] protected Rigidbody2D _rigidbody2D;

        protected Transform _transform;
        public string Id => _id.Value;

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
            DestroyProjectile();
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
            Destroy(gameObject);
        }
    }
}
