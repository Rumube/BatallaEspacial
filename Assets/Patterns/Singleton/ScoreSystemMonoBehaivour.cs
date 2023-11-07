using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystemMonoBehaivour : MonoBehaviour
    {
        private static ScoreSystemMonoBehaivour _instance;
        private int _currentScore;
        public static ScoreSystemMonoBehaivour Instance()
        {
            if(_instance == null)
            {
                var gameObject = new GameObject();
                _instance  = gameObject.AddComponent<ScoreSystemMonoBehaivour>();
                gameObject.name = "ScoreSystemMonoBehaivour";
            }
            return _instance;
        }

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
        }
    }
}


