using Common;
using Common.Commands;
using Patterns.Command;
using Patterns.ServiceLocator;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameMenuView : MonoBehaviour, InGameMenuMediator, EventObserver
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private GameOverView _gameOverView;

        private CommandQueue _commandQueue;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonPressed);
            _pauseMenuView.Configure(this);
            _victoryView.Configure(this);
            _gameOverView.Configure(this);
        }

        private void Start()
        {
            HideAllMenus();
            _commandQueue = ServiceLocator.Instance.GetService<CommandQueue>();

            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.Victory, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.GameOver, this);

        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.Victory, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.GameOver, this);
        }

        private void HideAllMenus()
        {
            _pauseMenuView.Hide();
            _victoryView.Hide();
            _gameOverView.Hide();
        }

        public void OnBackToMenuPressed()
        {
            _commandQueue.AddCommand(new LoadSceneCommand("Menu"));
            ResumeGame();
        }

        public void OnRestartPressed()
        {
            HideAllMenus();
            ResumeGame();
            _commandQueue.AddCommand(new RestartBattleCommand());
        }

        public void OnResumePressed()
        {
            _pauseMenuView.Hide();
            ResumeGame();
        }

        private void OnPauseButtonPressed()
        {
            _commandQueue.AddCommand(new PauseGameCommand());
            _pauseMenuView.Show();
        }

        private void ResumeGame()
        {
            _commandQueue.AddCommand(new ResumeGameCommand());
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                _victoryView.Show();
                return;
            }
            
            if (eventData.EventId == EventIds.GameOver)
            {
                _gameOverView.Show();
                return;
            }
        }
    }
}