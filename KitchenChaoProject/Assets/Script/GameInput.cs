using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameController gameController;

    private void Awake()
    {
        gameController = new GameController();
        gameController.Player.Enable();
    }

    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector2 = gameController.Player.Move.ReadValue<Vector2>();

        return new Vector3(inputVector2.x, 0, inputVector2.y).normalized;
    }
}
