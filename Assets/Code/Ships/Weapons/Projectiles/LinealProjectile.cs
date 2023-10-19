using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LinealProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;

        private void Start()
        {
            _rigidbody2D.velocity = transform.up * _speed;
            StartCoroutine(DestroyIn(4f));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}