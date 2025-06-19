using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(PlayerController player)
    {
        if (player.IsHaveKitchenObject())
        {
            if (IsHaveKitchenObject())
            {
                Debug.Log("当前柜台不为空");
            }
            else
            {
                Debug.Log("当前柜台为空");
                TransferKitchenObject(player, this);
            }
        }
        else
        {
            if (IsHaveKitchenObject())
            {
                Debug.Log("当前柜台不为空");
                TransferKitchenObject(this, player);
            }
            else
            {
                Debug.Log("当前柜台为空");
                
            }
        }
    }
}
