using Battle;
using Common;
using Common.Commands;
using Patterns.Command;
using Patterns.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] Button _restartButton;
        [SerializeField] Button _backToMenu;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _backToMenu.onClick.AddListener(BackToMenu);
        }

        private void Start()
        {
            gameObject.SetActive(false);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.GameOver, this);
        }

        private void BackToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));

        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }

        private void RestartGame()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new StartBattleCommand());
            gameObject.SetActive(false);
        }
    }
}

