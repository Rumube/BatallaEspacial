using Common;
using Patterns.Facade;
using Ships.Common;
using System;
using UnityEngine;

namespace Battle
{
    public class GameState : MonoBehaviour, EventObserver
    {
        private enum GameStates
        {
            Playing,
            GameOver,
            Victory
        }

        [SerializeField] private GameFacade _gameFacade;

        private int _aliveShips;
        private bool _allShipSpawned;
        private GameStates _currentGameState;

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.AllShipSpawned, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.AllShipSpawned, this);
        }

        public void Reset()
        {
            _currentGameState = GameStates.Playing;
            _aliveShips = 0;
            _allShipSpawned = false;
        }
        public void Process(EventData eventData)
        {
            if(_currentGameState != GameStates.Playing)
            {
                return;
            }

            if (eventData.EventId == EventIds.ShipSpawned)
            {
                _aliveShips++;
            }
            else if (eventData.EventId == EventIds.ShipDestroyed)
            {
                _aliveShips--;

                var shipDestroyedEventData = (ShipDestroyedEventData)eventData;

                if (shipDestroyedEventData.Team == Teams.Ally)
                {
                    _currentGameState = GameStates.GameOver;
                    _gameFacade.StopBattle();
                    EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
                    return;
                }

            }
            else if (eventData.EventId == EventIds.AllShipSpawned)
            {
                _allShipSpawned = true;
            }

            CheckGameState();
        }

        private void CheckGameState()
        {
            if(_aliveShips == 0 && _allShipSpawned)
            {
                _gameFacade.StopBattle();
                _currentGameState = GameStates.Victory;
                Debug.Log("Victoria");
                EventQueue.Instance.EnqueueEvent(new EventData(EventIds.Victory));
            }
        }
    }
}