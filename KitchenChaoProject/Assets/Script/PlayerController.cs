using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnSpeed = 10f;

    private bool isWalking = false;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        
        isWalking = direction != Vector3.zero;
        transform.position += direction * Time.deltaTime * moveSpeed;

        if (direction.magnitude != 0)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * turnSpeed);
        }
    }

    


    public bool GetIsWalking(){
        return isWalking;
    }
}
