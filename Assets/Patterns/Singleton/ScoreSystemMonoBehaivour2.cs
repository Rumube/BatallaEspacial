using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystemMonoBehaivour2 : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private static ScoreSystemMonoBehaivour2 _instance;
        private int _currentScore;

        private void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
        }

        public static ScoreSystemMonoBehaivour2 Instance()
        {
            return _instance;
        }

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
            _text.SetText(_currentScore.ToString());
        }
    }
}


