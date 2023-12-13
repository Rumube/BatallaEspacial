using Patterns.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ScoreSystem = Common.Score.ScoreSystem;

namespace UI
{
    public class VictoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] Button _restartButton;
        [SerializeField] Button _backToMenuButton;
        private InGameMenuMediator _mediador;

        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartPressed);
            _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        }

        public void Configure(InGameMenuMediator mediador)
        {
            _mediador = mediador;
        }

        public void Show()
        {
            var currentScore = ServiceLocator.Instance.GetService<ScoreSystem>().CurrentScore;
            _scoreText.SetText(currentScore.ToString());
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnBackToMenuPressed()
        {
            _mediador.OnBackToMenuPressed();
        }

        private void OnRestartPressed()
        {
            _mediador.OnRestartPressed();
        }
    }
}

