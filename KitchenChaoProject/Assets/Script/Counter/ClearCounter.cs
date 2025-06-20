using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(PlayerController player)
    {
        if (player.IsHaveKitchenObject())
        {// 玩家手上有物品
            if (player.GetKitchenObject().
                TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
            {// 手上是盘子
                if (!IsHaveKitchenObject())
                {// 当前柜台为 空
                    TransferKitchenObject(player, this);
                }
                else
                {// 当前柜台不为 空
                    if (plateKitchenObject.AddKitchenObjectSO(GetKitchenObjectSO()))
                    {
                        DestroykitchenObject();
                    }
                }
            }
            else
            {// 手上是食材
                if (IsHaveKitchenObject())
                {// 当前柜台为 不空
                    if (GetKitchenObject().TryGetComponent<PlateKitchenObject>(out plateKitchenObject))
                    {// 柜台上是盘子
                        if (plateKitchenObject.AddKitchenObjectSO(player.GetKitchenObjectSO()))
                        {
                            player.DestroykitchenObject();
                        }
                    }
                }
                else
                {// 当前柜台为 空
                    TransferKitchenObject(player, this);
                }
            }
            #region Old
            // 手上有食材
            // if (IsHaveKitchenObject())
            // {
            //     // Debug.Log("当前柜台不为空");
            // }
            // else
            // {
            //     // Debug.Log("当前柜台为空");
            //     TransferKitchenObject(player, this);
            // }
            #endregion
        }
        else
        {
            if (IsHaveKitchenObject())
            {
                // Debug.Log("当前柜台不为空");
                TransferKitchenObject(this, player);
            }
            else
            {
                // Debug.Log("当前柜台为空");
            }
        }
    }
}
