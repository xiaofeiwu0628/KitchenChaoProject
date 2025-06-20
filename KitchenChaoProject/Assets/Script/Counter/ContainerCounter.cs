using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private ContainerCounterVisual coutainerCounterVisual;
    public override void Interact(PlayerController player)
    {
        if (player.IsHaveKitchenObject()) return;

        coutainerCounterVisual.PlayOpen();

        CreateKitchenObject(kitchenObjectSO.prefab);

        TransferKitchenObject(this, player);
    }
}
