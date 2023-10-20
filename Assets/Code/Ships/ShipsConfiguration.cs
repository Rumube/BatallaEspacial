using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ships
{
    [CreateAssetMenu(menuName = "Create ShipsConfiguration", fileName = "ShipsConfiguration", order = 1)]
    public class ShipsConfiguration : ScriptableObject
    {
        [SerializeField] private ShipMediator[] _shipsPrefabs;
        private Dictionary<string, ShipMediator> _idToShipPrefab;

        private void Awake()
        {
            _idToShipPrefab = new Dictionary<string, ShipMediator>();

            foreach (var ship in _shipsPrefabs)
            {
                _idToShipPrefab.Add(ship.Id, ship);
            }
        }

        public ShipMediator GetShipById(string id)
        {
            if (!_idToShipPrefab.TryGetValue(id, out var ship))
            {
                throw new System.Exception($"Ship {id} not found");
            }
            return ship;
        }
    }
}

