using Common;
using Patterns.ServiceLocator;
using Ships.Common;
using System;

namespace Battle.States
{
    public class PlayingState : GameState, EventObserver
    {
        private Action<GameStateController.GameStates> _onEndedCallBack;
        private int _aliveShips;
        private bool _allShipSpawned;

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _onEndedCallBack = onEndedCallback;
            _aliveShips = 0;
            _allShipSpawned = false;

            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.AllShipSpawned, this);
        }

        public void Stop()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.AllShipSpawned, this);
        }

        public void Process(EventData eventData)
        {
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
                    _onEndedCallBack?.Invoke(GameStateController.GameStates.GameOver);
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
            if (_aliveShips == 0 && _allShipSpawned)
            {
                _onEndedCallBack?.Invoke(GameStateController.GameStates.Victory);
            }
        }
    }
}