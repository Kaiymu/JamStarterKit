using Manager.Gameplay.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Movement {
    public class PlayerMovement : MonoBehaviour, IPlayerMovement
    {
        // Créer une interface ?
        [Header("Speed of the character")]
        [SerializeField]
        [Range(1, 100)]
        private float _playerSpeed;

        private Vector2 _move;

        private void Start()
        {
            InputManager.OnMove += OnMove;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.LogError(context.phase);
            if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)
            {
                _move = context.ReadValue<Vector2>();
            }
            else
            {
                _move = Vector2.zero;
            }
        }

        private void Update()
        {
            transform.position = transform.position + new Vector3(_move.x * Time.deltaTime * _playerSpeed, _move.y * Time.deltaTime * _playerSpeed, 0);
        }
    }
}