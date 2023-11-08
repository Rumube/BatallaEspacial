using UnityEngine;

namespace Patterns.EventQueue
{
    public class ScoreSystem
    {
        public static ScoreSystem Instance => _instance ?? (_instance = new ScoreSystem());
        private static ScoreSystem _instance;

        private ScoreSystem() { }

        public void AddScore(int scoreToAD)
        {
            Debug.Log("Score added");
        }
    }
}