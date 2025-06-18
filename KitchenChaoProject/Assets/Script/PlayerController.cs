using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking = false;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleInteraction();
    }

    private void HandleMovement()
    {
        
        Vector3 direction = gameInput.GetMovementDirectionNormalized();

        isWalking = direction != Vector3.zero;
        transform.position += direction * Time.deltaTime * moveSpeed;

        if (direction.magnitude != 0)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * turnSpeed);
        }
    }

    private void HandleInteraction()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit,2f))
        {
            
        }
    }


    public bool GetIsWalking(){
        return isWalking;
    }
}
