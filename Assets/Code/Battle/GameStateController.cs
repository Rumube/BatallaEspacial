using Battle.States;
using Common;
using Common.Commands;
using Patterns.ServiceLocator;
using Ships.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Battle
{
    public class GameStateController : MonoBehaviour
    {
        public enum GameStates
        {
            Playing,
            GameOver,
            Victory
        }

        private Dictionary<GameStates, GameState> _idToState;
        private GameState _currentState;

        private void Start()
        {
            var stopBattleCommand = new StopBattleCommand();
            _idToState = new Dictionary<GameStates, GameState>
            {
                {GameStates.Playing, new PlayingState()},
                {GameStates.GameOver, new GameOverState(stopBattleCommand)},
                {GameStates.Victory, new VictoryState(stopBattleCommand)}
            };


            _currentState = GetState(GameStates.Playing);
            _currentState.Start(ChangeToNextState);
        }

        private async void ChangeToNextState(GameStates nextState)
        {
            await Task.Yield();
            _currentState.Stop();
            _currentState = GetState(nextState);
            _currentState.Start(ChangeToNextState);
        }

        public void Reset()
        {
            ChangeToNextState(GameStates.Playing);
        }

        private GameState GetState(GameStates gameState)
        {
            return _idToState[gameState];
        }
    }
}