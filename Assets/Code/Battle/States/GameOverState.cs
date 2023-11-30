using Common;
using System;
using Patterns.ServiceLocator;
using Patterns.Command;
using Common.Commands;

namespace Battle.States
{
    public class GameOverState : GameState
    {
        private readonly Command _stopCommand;
        public GameOverState(Command stopCommand)
        {
            _stopCommand = stopCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                                   .AddCommand(_stopCommand);

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}