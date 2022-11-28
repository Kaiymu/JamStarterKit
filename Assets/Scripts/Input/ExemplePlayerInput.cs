using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Input
{
    /// <summary>
    /// A simple exemple player input, that gets triggered automaticly by Unity
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public class ExemplePlayerInput : MonoBehaviour
    {
        private Vector2 _look;
        private Vector3 _direction;

        // All of this callback can be found on the prefab attached to this script
        // Just click on "PlayerInput" script -> Events -> Name of the group action
        // And just drag'n'drop whatever callback you want. 
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)
            {
                _direction = context.ReadValue<Vector2>();
            }
            else
            {
                _direction = Vector2.zero;
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            _look = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            _direction.y = context.ReadValue<float>();
        }

        private void Update()
        {
            transform.position = transform.position + (_direction * Time.deltaTime * 10);
        }

        // I added here simple "context" exemple, if you want to do specific action on how the input was made.
        // In Unity's exemple they used this state to make some kind of "Charging" shoot
        public void OnFire(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
                    break;
                case InputActionPhase.Canceled:
                    break;
            }
        }
    }
}
