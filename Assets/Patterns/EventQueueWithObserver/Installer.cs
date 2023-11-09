using UnityEngine;

namespace Patterns.EventQueueWithObserver
{
    public class Installer : MonoBehaviour
    {
        private void Start ()
        {
            new ScoreSystem();
            new AchivementsSystem();
        }
    }
}