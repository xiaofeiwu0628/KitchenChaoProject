using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField]CuttingRecipeListSO cuttingRecipeList;
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

    public override void InteractOperate(PlayerController player)
    {
        if (IsHaveKitchenObject())
        {
            GameObject kitchenObject = cuttingRecipeList.GetOutput(GetKitchenObject().GetKitchenObjectSO()).prefabe;
            if (kitchenObject)
            {
                DestroykitchenObject();
                CreateKitchenObject(kitchenObject);
            }
        }
    }
}
