using Patterns.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ScoreSystem = Common.Score.ScoreSystem;

namespace UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] Button _restartButton;
        [SerializeField] Button _backToMenu;
        private InGameMenuMediator _mediator;

        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartGamePressed);
            _backToMenu.onClick.AddListener(OnBackToMenuPressed);
        }

        public void Configure(InGameMenuMediator mediator)
        {
            _mediator = mediator;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            var currentScore = ServiceLocator.Instance.GetService<ScoreSystem>().CurrentScore;
            _scoreText.SetText(currentScore.ToString());
            gameObject.SetActive(true);
        }

        private void OnBackToMenuPressed()
        {
            _mediator.OnBackToMenuPressed();
        }

        private void OnRestartGamePressed()
        {
            _mediator.OnRestartPressed();
        }
    }
}

