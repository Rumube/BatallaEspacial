using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Patterns.ServiceLocator
{
    public class ScoreSystemMonoBehaivour2 : MonoBehaviour, IScoreSystem
    {
        [SerializeField] private TextMeshProUGUI _text;

        private int _currentScore;

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
            _text.SetText(_currentScore.ToString());
        }
    }
}


