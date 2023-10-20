using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Create ShipId", fileName = "ShipId", order = 0)]
    public class ShipId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}