using UnityEngine;

namespace Patterns.EventQueue
{
    public class AchivementsSystem
    {
        public static AchivementsSystem Instance => _instance ?? (_instance = new AchivementsSystem());
        private static AchivementsSystem _instance;

        private int _numberOfEnemiesDead;

        public AchivementsSystem()
        {
            _numberOfEnemiesDead = 0;
        }

        public void EnemyDeath()
        {
            Debug.Log("Enemy Death");
            _numberOfEnemiesDead += 1;

            if(_numberOfEnemiesDead == 3)
            {
                var eventData = new EventData(EventIds.AchivementUnlocked);
                EventQueue.Instance.EnqueueEvent(eventData);
            }
        }
    }
}