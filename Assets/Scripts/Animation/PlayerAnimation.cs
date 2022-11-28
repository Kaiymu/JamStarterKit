using Manager.Gameplay.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Header("Trigger name when pressing the fire input")]
        [SerializeField]
        private string _fireAnimationName;

        [Header("Trigger name when move input")]
        [SerializeField]
        private string _moveAnimationName;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            InputManager.OnFire += OnFire;
            InputManager.OnMove += OnMove;
        }

        private void OnFire(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                /// The animation is defined within the .anim file, and can modify any property of the element, hence why we don't care if it's 2D or 3D
                /// Brackeys as a fantastic video around that <see href="https://www.youtube.com/watch?v=hkaysu1Z-N8"> that you can see here </see> 
                /// You can call SetFloat, SetBool, SetString and SetTriger
                _animator.SetTrigger(_fireAnimationName);
            }
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                _animator.SetTrigger(_moveAnimationName);
            }
        }

        private void OnDestroy()
        {
            _animator = null;
            InputManager.OnFire -= OnFire;
            InputManager.OnMove -= OnMove;
        }
    }
}