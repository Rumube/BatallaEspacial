using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image _screenFadeImage;

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

