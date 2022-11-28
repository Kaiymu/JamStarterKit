using Manager.Gameplay.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Movement {
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Speed of the character")]
        [SerializeField]
        [Range(1, 100)]
        private float _moveSpeed = 10f;

        private Vector3 _direction;

        private void Start()
        {
            InputManager.OnMove += OnMove;
        }

        /// <summary>
        /// Change the move vector to the current context value.
        /// If you prefer, you can have one event per context, if that's the case change that into the input manager.
        /// </summary>
        /// <param name="context">Input context sent by the InputManager.cs</param>
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

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = transform.position + (_direction * Time.deltaTime * _moveSpeed);
        }
    }
}