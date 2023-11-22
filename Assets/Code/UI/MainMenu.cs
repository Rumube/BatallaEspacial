using Common.Commands;
using Patterns.Command;
using Patterns.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(OnStartButtonPressed);
        }

        private void OnStartButtonPressed()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadGameSceneCommand());
        }
    }
}