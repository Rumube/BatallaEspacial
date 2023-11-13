using static Patterns.State.Enemy;

namespace Patterns.State.States
{
    public interface EnemyState
    {
        public void Start();

        public void Stop();

        public bool Update();

        public EnemyStates GetNextState();
    }
}