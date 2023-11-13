using Common;
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

            EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.AllShipSpawned, this);
        }

        public void Stop()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.AllShipSpawned, this);
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