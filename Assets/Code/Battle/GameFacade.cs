using Ships;
using Ships.Enemies;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private ScoreView _scoreView;

        public void StartBattle()
        {
            _scoreView.Reset();
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            _screenFade.Hide();
        }

        public void StopBattle()
        {
            _enemySpawner.StopAndReset();
            _shipInstaller.DestroyUserShip();
            _screenFade.Show();
        }
    }
}

