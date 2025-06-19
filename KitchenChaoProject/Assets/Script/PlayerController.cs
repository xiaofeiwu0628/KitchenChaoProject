using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : KitchenObjectHolder
{
    public static PlayerController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking = false;
    private BaseCounter selectedCounter;

    public void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnOperateAction += GameInput_OnOperateAction;
    }

    private void GameInput_OnOperateAction(object sender, EventArgs e)
    {
        selectedCounter?.InteractOperate(this);
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        selectedCounter?.Interact(this);
    }

    private void Update()
    {
        HandleInteraction();
    }

    private void FixedUpdate()
    {
        HandleMovement();
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
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2f, LayerMask.GetMask("Counter")))
        {
            if (hit.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {
                // counter.Interact();
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    public void SetSelectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();
            counter?.SelectCounter();
            this.selectedCounter = counter;
        }
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }
}
