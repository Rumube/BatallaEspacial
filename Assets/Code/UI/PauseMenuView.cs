using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;

        private InGameMenuView _mediator;

        public void Configure(InGameMenuView inGameMenuView)
        {
            _mediator = inGameMenuView;
        }

        private void Awake()
        {
            _resumeButton.onClick.AddListener(OnResumePressed);
            _restartButton.onClick.AddListener(OnRestartPressed);
            _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void OnBackToMenuPressed()
        {
            _mediator.OnBackToMenuPressed();
        }

        private void OnRestartPressed()
        {
            _mediator.OnRestartPressed();
        }

        private void OnResumePressed()
        {
            _mediator.OnResumePressed();
        }

        internal void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}