using Patterns.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacadeImpl : MonoBehaviour, GameFacade
    {
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameStateController _gameState;

        public void StartBattle()
        {
            ServiceLocator.Instance.GetService<GameStateController>().Reset();
            ServiceLocator.Instance.GetService<ScoreView>().Reset();
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
        }

        public void StopBattle()
        {
            _enemySpawner.StopAndReset();
            ServiceLocator.Instance.GetService<LoadingScreen>().Show();
        }
    }
}

