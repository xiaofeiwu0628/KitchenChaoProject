using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnOperateAction;
    private GameController gameController;

    private void Awake()
    {
        gameController = new GameController();
        gameController.Player.Enable();

        gameController.Player.Interact.performed += Interact_Performed;
        gameController.Player.Operate.performed += Operate_Performed;
    }

    private void Operate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext ctX)
    {
        OnOperateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector2 = gameController.Player.Move.ReadValue<Vector2>();

        return new Vector3(inputVector2.x, 0, inputVector2.y).normalized;
    }

}
