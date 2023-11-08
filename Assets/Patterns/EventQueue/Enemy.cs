using UnityEngine;

namespace Patterns.EventQueue
{
    public class Enemy : MonoBehaviour
    {
        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                var enemyDeathEventData = new EnemyDeathEventData(10);
                EventQueue.Instance.EnqueueEvent(enemyDeathEventData);
            }
        }
    }
}