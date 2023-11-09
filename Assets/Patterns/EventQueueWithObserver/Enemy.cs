using UnityEngine;

namespace Patterns.EventQueueWithObserver
{
    public class Enemy : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var enemyDeathEventData = new EnemyDeathEventData(10);
                EventQueue.Instance.EnqueueEvent(enemyDeathEventData);
            }
        }
    }
}