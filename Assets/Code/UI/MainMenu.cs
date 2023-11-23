using Common.Commands;
using Patterns.Command;
using Patterns.Composite.Command;
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
            var loadGameSceneCommand = new LoadGameSceneCommand();

            //var compositeCommand = new CompositeCommand();

            //compositeCommand.AddCommand(new LoadSceneCommand("Game"));
            //compositeCommand.AddCommand(new StartBattleCommand());

            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(loadGameSceneCommand);
        }
    }
}