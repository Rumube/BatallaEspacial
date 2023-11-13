using Common;
using System;

namespace Battle.States
{
    public class GameOverState : GameState
    {
        private readonly GameFacade _gameFacade;

        public GameOverState(GameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _gameFacade.StopBattle();
            EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}