using Ships.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileId _id;
    public string Id => _id.Value;

}
