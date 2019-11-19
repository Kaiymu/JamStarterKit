using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.Users;

[RequireComponent(typeof(PlayerInput))]
public class BasicPlayerInput : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;
    private PlayerInput _playerInput;

    private Vector2 m_Look;
    private float m_Jump;
    private Vector2 m_Move;
    private bool m_Charging;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    // Called when the device is disconnected
    public void DeviceLostEvent(PlayerInput test)
    {
        Destroy(gameObject);
    }

    // All of this callback can be found on the prefab attached to this script
    // Just click on "PlayerInput" script -> Events -> Name of the group action
    // And just drag'n'drop whatever callback you want.
    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        m_Jump = context.ReadValue<float>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Canceled:
                break;
        }
    }

}
