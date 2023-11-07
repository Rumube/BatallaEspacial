using UnityEngine;

namespace Patterns.Singleton
{
    public class Consumer : MonoBehaviour
    {
        private void Start()
        {
            var scoreSystem = ScoreSystemMonoBehaivour2.Instance();
            scoreSystem.AddScore(100);
            ScoreSystemMonoBehaivour2.Instance().AddScore(100);
        }
    }
}
