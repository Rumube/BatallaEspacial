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
            _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
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

