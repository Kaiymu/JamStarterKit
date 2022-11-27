using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerMovement
{
    public void OnMove(InputAction.CallbackContext context);
}
