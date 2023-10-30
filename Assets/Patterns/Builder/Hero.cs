using Patterns.Builder.Armors;
using Patterns.Builder.Weapons;
using UnityEngine;

namespace Patterns.Builder
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform _weapongPosition;
        [SerializeField] private Transform _armorPosition;

        public void SetComponents(Weapon weapon, Armor armor)
        {
            weapon.transform.position = _weapongPosition.position;
            armor.transform.position = _armorPosition.position;
        }
    }
}

