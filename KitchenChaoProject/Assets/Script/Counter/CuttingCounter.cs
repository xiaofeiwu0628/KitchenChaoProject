using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public static event EventHandler OnRecipeCut;

    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;

    [SerializeField] private ProgressBarUI progressBarUI;

    [SerializeField] private CuttingCounterVisual cuttingCounterVisual;

    private int cuttingCount = 0;

    public override void Interact(PlayerController player)
    {
        if (player.IsHaveKitchenObject())
        {
            if (IsHaveKitchenObject())
            {

            }
            else
            {
                cuttingCount = 0;
                TransferKitchenObject(player, this);
            }
        }
        else
        {
            if (IsHaveKitchenObject())
            {
                // Debug.Log("当前柜台不为空");
                progressBarUI.Hide();
                TransferKitchenObject(this, player);
            }
            else
            {
                // Debug.Log("当前柜台为空");
            }
        }
    }

    public override void InteractOperate(PlayerController player)
    {
        if (IsHaveKitchenObject())
        {
            if (cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(),
                                                      out CuttingRecipeSO cuttingRecipe))
            {
                Cut();
                progressBarUI.UpdateProgress((float)cuttingCount / cuttingRecipe.cuttingCountMAX);

                if (cuttingCount == cuttingRecipe.cuttingCountMAX)
                {
                    DestroykitchenObject();
                    CreateKitchenObject(cuttingRecipe.output.prefab);
                }
            }
        }
    }

    public void Cut()
    {
        OnRecipeCut?.Invoke(this, EventArgs.Empty);
        cuttingCount++;
        cuttingCounterVisual.PlayCut();
    }

    public new static void ClearStaticData()
    {
        OnRecipeCut = null;
    }
}
