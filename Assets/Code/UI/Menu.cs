using Battle;
using Patterns.ServiceLocator;
using Ships;
using Ships.Enemies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private Button _stopBattleButton;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(StartBattle);
            _stopBattleButton.onClick.AddListener(StopBattle);
        }

        private void StartBattle()
        {
             ServiceLocator.Instance.GetService<GameFacade>().StartBattle();
        }

        private void StopBattle()
        {
            ServiceLocator.Instance.GetService<GameFacade>().StopBattle();
        }
    }
}

