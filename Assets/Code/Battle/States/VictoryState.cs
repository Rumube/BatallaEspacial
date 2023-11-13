using Common;
using System;
using static Battle.GameStateController;

namespace Battle.States
{
    public class VictoryState : GameState
    {
        private readonly GameFacade _gameFacade;

        public VictoryState(GameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _gameFacade.StopBattle();
            EventQueue.Instance.EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {
        }
    }
}