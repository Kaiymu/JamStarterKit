using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager.Gameplay.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        private SimpleControls _simpleControls;
        [SerializeField]
        private PlayerInputManager _playerInputManager;

        public delegate void MyDelegate(InputAction.CallbackContext context);
        public static MyDelegate OnMove;

        // Tu peux créer ton propre input system, où utiliser celui-ci.
        private void Awake()
        {
            _playerInputManager = gameObject.AddComponent<PlayerInputManager>();
            _simpleControls = new SimpleControls();

            _playerInputManager.joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
            
            _playerInputManager.onPlayerJoined += _playerInputManager_onPlayerJoined;
        }

        /// <summary>
        ///  Tester pour voir si ça marche :).
        /// </summary>
        /// <param name="obj"></param>
        private void _playerInputManager_onPlayerJoined(PlayerInput obj)
        {
            Debug.LogError("OnPlayerJoined"); 
        }

        /// <summary>
        /// You have to enable the input system, otherwise it won't get recognized
        /// </summary>
        private void OnEnable()
        {
            _simpleControls.Enable();
        }

        /// <summary>
        /// And disable it, if your element becomes hidden for exemple.
        /// </summary>
        private void OnDisable()
        {
            _simpleControls.Disable();
        }

        /// <summary>
        /// On the start, you can callback every feedback here
        /// </summary>
        private void Start()
        {
            // Move
            _simpleControls.gameplay.Move.started += (ctx) =>
            {
                OnMove(ctx);
            };

            _simpleControls.gameplay.Move.performed += (ctx) =>
            {
                OnMove(ctx);
            };

            _simpleControls.gameplay.Move.canceled += (ctx) =>
            {
                OnMove(ctx);
            };

        }

        private void OnDestroy()
        {
            _simpleControls.gameplay.Move.started -= (ctx) =>
            {
                OnMove(ctx);
            };

            _simpleControls.gameplay.Move.performed -= (ctx) =>
            {
                OnMove(ctx);
            };

            _simpleControls.gameplay.Move.canceled -= (ctx) =>
            {
                OnMove(ctx);
            };
        }
    }
}
