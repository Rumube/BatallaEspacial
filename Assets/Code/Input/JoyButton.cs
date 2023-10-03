using UnityEngine;
using UnityEngine.EventSystems;

namespace Inputs
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool IsPressed {  get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressed = false;
        }
    }
}