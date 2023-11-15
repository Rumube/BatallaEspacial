using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadingScreen : MonoBehaviour
    {
        public static LoadingScreen Instance { get; private set; }
        [SerializeField] private Image _screenFadeImage;


        private void Awake()
        {
            Instance = this;
        }

        public void Show()
        {
            _screenFadeImage.enabled = true;
        }

        public void Hide()
        {
            _screenFadeImage.enabled = false;
        }
    }
}

