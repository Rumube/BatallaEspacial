using System;

namespace Battle.States
{
    public interface GameState
    {
        void Start(Action<GameStateController.GameStates> onEndedCallback);
        void Stop();
    }
}