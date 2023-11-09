using Patterns.EventQueue;
using UnityEngine;

namespace Patterns.EventQueueWithObserver
{
    public class AchivementsSystem : EventObserver
    {
        private int _numberOfEnemiesDead;

        public AchivementsSystem()
        {
            _numberOfEnemiesDead = 0;
            EventQueue.Instance.Subscribe(EventIds.EnemyDeath, this);
            EventQueue.Instance.Subscribe(EventIds.AchievementUnlocked, this);
        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId != EventIds.EnemyDeath)
            {
                return;
            }

            Debug.Log("Enemy Death");
            _numberOfEnemiesDead++;

            if(_numberOfEnemiesDead == 3)
            {
                var newEventData = new EventData(EventIds.AchievementUnlocked);
                EventQueue.Instance.EnqueueEvent(newEventData);
            }
        }
    }
}