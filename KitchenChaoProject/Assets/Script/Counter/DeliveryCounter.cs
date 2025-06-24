using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(PlayerController player)
    {
        if (player.IsHaveKitchenObject() &&
            player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject _plateKitchenObject))
        {
            // TODO：判断是否为正确的菜
            OrderManager.Instance.DeliverRecipe(_plateKitchenObject);        

            player.DestroykitchenObject();
        }
    }
}
