using Battle;
using Common;
using Common.Commands;
using Patterns.Command;
using Patterns.ServiceLocator;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VictoryView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] Button _restartButton;
        [SerializeField] Button _backToMenuButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _backToMenuButton.onClick.AddListener(BackToMenu);
        }

        private void Start()
        {
            gameObject.SetActive(false);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.Victory, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.Victory, this);
        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId == EventIds.Victory)
            {
                _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }

        private void BackToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));

        }

        private void RestartGame()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new StartBattleCommand());
            gameObject.SetActive(false);
        }
    }
}

