using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CurveProjectile : Projectile
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _horizontalPosition;

    private Vector3 _currentPosition;
    private float _currentTime;
    private Transform _transform;

    private void Start()
    {
        _currentTime = 0;
        _transform = transform;
        _currentPosition = _transform.position;
        StartCoroutine(DestroyIn(4f));
    }

    private void FixedUpdate()
    {
        _currentPosition += _transform.up * (_speed * Time.deltaTime);
        var horizontalPosition = _transform.right * _horizontalPosition.Evaluate(_currentTime);
        _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

        _currentTime += Time.deltaTime;
    }

    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}

