using UnityEngine;

namespace Patterns.ServiceLocator
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private ScoreSystemMonoBehaivour2 _scoreSystemMonoBehaivour2;
        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<IScoreSystem>(new ScoreSystem());
            //ServiceLocator.Instance.RegisterService(_scoreSystemMonoBehaivour2);
        }
    }
}