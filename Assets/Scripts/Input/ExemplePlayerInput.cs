using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A simple exemple player input, that gets triggered automaticly by Unity
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class ExemplePlayerInput : MonoBehaviour
{
    private Vector2 _look;
    private Vector2 _move;
    private float _jump;

    /// <summary>
    /// Called when the player connects the device attached to that gameobject
    /// </summary>
    public void DeviceGainedEvent()
    {
        Debug.LogError("Device connected");
    }

    /// <summary>
    /// Called when the player disconnected the device attached to that gameobject
    /// </summary>
    public void DeviceLostEvent()
    {
        Destroy(gameObject);
    }

    // All of this callback can be found on the prefab attached to this script
    // Just click on "PlayerInput" script -> Events -> Name of the group action
    // And just drag'n'drop whatever callback you want. 
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)
        {
            _move = context.ReadValue<Vector2>();
        } else
        {
            _move = Vector2.zero;
        }
    }

    private void Update()
    {
        transform.position = transform.position + new Vector3(_move.x * Time.deltaTime * 10, _move.y * Time.deltaTime * 10, 0);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _look = context.ReadValue<Vector2>();
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        _look = context.ReadValue<Vector2>();
        var test = new Vector3(_look.x, _look.y, Camera.main.nearClipPlane + 1);

        transform.LookAt(Camera.main.ScreenToWorldPoint(test));

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _jump = context.ReadValue<float>();
    }

    // I added here simple "context" exemple, if you want to do specific action on how the input was made.
    // In Unity's exemple they used this state to make some kind of "Charging" shoot
    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("BasicPlayerInput : Fire");
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
