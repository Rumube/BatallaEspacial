using Common;
using Common.Commands;
using Patterns.Command;
using Patterns.ServiceLocator;
using System;

namespace Battle.States
{
    public class VictoryState : GameState
    {
        private readonly Command _stopBattleCommand;

        public VictoryState(Command stopBattleCommand)
        {
            _stopBattleCommand = stopBattleCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(_stopBattleCommand);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {
        }
    }
}