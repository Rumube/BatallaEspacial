using Common;
using Ships.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        private ShipFactory _shipFactory;
        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;
        private bool _canSpawn;

        private void Awake()
        {
            _shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
        }

        public void StartSpawn()
        {
            _canSpawn = true;
        }

        internal void StopAndReset()
        {
            _canSpawn = false;
            _currentTimeInSeconds = 0;
            _currentConfigurationIndex = 0;
        }

        private void Update()
        {
            if (!_canSpawn)
            {
                return;
            }
            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }

            _currentTimeInSeconds += Time.deltaTime;

            var spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];

            if (spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            _currentConfigurationIndex += 1;
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            for (int i = 0; i < spawnConfiguration.ShipToSpawnConfiguration.Length; i++)
            {
                var shipConfiguration = spawnConfiguration.ShipToSpawnConfiguration[i];
                var spawnPosition = _spawnPositions[i % _spawnPositions.Length];
                var shipBuilder = _shipFactory.Create(shipConfiguration.ShipId.Value);

                var ship = shipBuilder.WithPosition(spawnPosition.position)
                           .WithRotation(spawnPosition.rotation)
                           .WithInputMode(ShipBuilder.InputMode.Ai)
                           .WithCheckLimitsType(ShipBuilder.CheckLimitsTypes.InitialPosition)
                           .WithConfiguration(shipConfiguration)
                           .WithTeam(Teams.Enemy)
                           .Build();
            }
        }
    }
}

