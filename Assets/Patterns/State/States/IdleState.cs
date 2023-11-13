using UnityEngine;

namespace Patterns.State.States
{
    public class IdleState : EnemyState
    {
        private Enemy _context;
        private float _timeToWait;
        private float _currentTime;

        public IdleState(Enemy context, float timeToWait)
        {
            _context = context;
            _timeToWait = timeToWait;
        }

        public void Start()
        {
            _currentTime = 0;
        }

        public bool Update()
        {
            _currentTime += Time.deltaTime;

            return _currentTime >= _timeToWait;
        }

        public void Stop()
        {
        }

        public Enemy.EnemyStates GetNextState()
        {
            return Enemy.EnemyStates.FindTarget;
        }
    }
}