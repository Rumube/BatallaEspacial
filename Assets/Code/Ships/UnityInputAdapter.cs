using UnityEngine;

namespace Ships
{
    public class UnityInputAdapter : Input
    {
        public Vector2 GetDirection()
        {
            var horizontalDir = UnityEngine.Input.GetAxis("Horizontal");
            var verticalDir = UnityEngine.Input.GetAxis("Vertical");

            return new Vector2(horizontalDir, verticalDir);
        }
    }
}
