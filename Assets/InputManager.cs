using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager.Gameplay.Input
{
    /// <summary>
    /// A custom input manager script to showcase some custom feature that can be done
    /// If you prefer, use the InputManager provided into the same scene.
    /// Documentation 
    /// <see href="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html">Quick start </see>
    /// <see href="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/HowDoI.html">How do I </see>
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        /// <summary>
        /// Serialization to the SimpleControls input actions.
        /// </summary>
        private SimpleControls _simpleControls;

        /// <summary>
        /// Basic event to notify when the move input as been pressed
        /// </summary>
        public delegate void OnMoveEvent(InputAction.CallbackContext context);
        public static OnMoveEvent OnMove;

        /// <summary>
        /// Called by Unity, see the order here <see href="https://docs.unity3d.com/Manual/ExecutionOrder.html"> the execution order</see> 
        /// </summary>
        private void Awake()
        {
            CreateCustomInput();
        }

        /// <summary>
        /// Exemple of how to create and bind input actions
        /// </summary>
        private void CreateCustomInput()
        {
            /// Creating a new control, serialized from the SimpleControls.inputactions
            _simpleControls = new SimpleControls();

            /// Binding a input action to notify when any key is press
            InputAction anyInputAction = new (binding: "/*/<button>");
            anyInputAction.performed += AnyInputAction;
            anyInputAction.Enable();

            // Getting callback when a device is added ore removed.
            InputSystem.onDeviceChange += OnDeviceChanged;
        }

        /// <summary>
        /// Called everytime any input is pressed
        /// </summary>
        /// <param name="obj">The context contain </param>
        private void AnyInputAction(InputAction.CallbackContext input)
        {
            Debug.Log($"InputManager : Input pressed : {input.control.displayName}");
        }

        /// <summary>
        /// Notifies everytime a device gets added or removed
        /// </summary>
        /// <param name="device"></param>
        /// <param name="change"></param>
        private void OnDeviceChanged(InputDevice device, InputDeviceChange change)
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log($"InputManager : New device added : {device}");
                    break;

                case InputDeviceChange.Removed:
                    Debug.Log($"InputManager : Device removed : {device}");
                    break;
            }
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
        /// You can callback every feedback here
        /// </summary>
        private void Start()
        {
            // Move, if you prefer to send one event per context, you also can
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

        /// <summary>
        /// Called when the monobehaviour get's destroyed, basically clean your mess here.
        /// </summary>
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

            InputSystem.onDeviceChange -= OnDeviceChanged;
        }
    }
}
