using UnityEngine;

namespace Patterns.ServiceLocator
{
    public class Consumer : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var scoreSystem = ServiceLocator.Instance.GetService<IScoreSystem>();
                scoreSystem.AddScore(100);
                ServiceLocator.Instance.GetService<IScoreSystem>().AddScore(100);
            }else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var scoreSystem = ServiceLocator.Instance.GetService<IScoreSystem>();
                scoreSystem.AddScore(100);
                ServiceLocator.Instance.GetService<IScoreSystem>().AddScore(100);
            }
        }
    }
}
