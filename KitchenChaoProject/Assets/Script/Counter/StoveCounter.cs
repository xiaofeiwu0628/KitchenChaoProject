using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    public enum StoveState
    {
        Idle,
        Frying,
        Burning
    }

    [SerializeField] private FryingRecipeListSO fryingRecipeList;

    private StoveState state = StoveState.Idle;
    private FryingRecipeSO fryingRecipe;
    private float fryingTimer = 0;

    public override void Interact(PlayerController player)
    {
        // 手上有食材
        if (player.IsHaveKitchenObject())
        {// 柜台无食材 and 手上的食材要为可以煎烤的食物
            if (!IsHaveKitchenObject() && fryingRecipeList.TryGetFryingRecipe(
            player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipeSO _fryingRecipe))
            {
                TransferKitchenObject(player, this);
                fryingRecipe = _fryingRecipe;
                StartFrying(fryingRecipe);
            }
        }
        else // 手上无食材
        {// 柜台有食材
            if (IsHaveKitchenObject())
            {
                state = StoveState.Idle;
                fryingTimer = 0;
                TransferKitchenObject(this, player);
            }
        }
    }

    public override void InteractOperate(PlayerController player)
    {

    }

    private void Update()
    {
        switch (state)
        {
            case StoveState.Idle:
                break;
            case StoveState.Frying:
                fryingTimer += Time.deltaTime;
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroykitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);

                    fryingRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(),
                        out FryingRecipeSO newFryingRecipe);
                    StartBurning(newFryingRecipe);
                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroykitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    state = StoveState.Idle;
                }
                break;
            default:
                break;
        }
    }

    public void StartFrying(FryingRecipeSO _fryingRecipe)
    {
        fryingTimer = 0;
        fryingRecipe = _fryingRecipe;
        state = StoveState.Frying;
    }

    public void StartBurning(FryingRecipeSO _fryingRecipe)
    {
        if (_fryingRecipe == null)
        {
            fryingTimer = 0;
            state = StoveState.Idle;
            Debug.LogWarning("无法获取Buring的食谱，无法进行BUring。");
            return;
        }
        fryingTimer = 0;
        fryingRecipe = _fryingRecipe;
        state = StoveState.Burning;

    } 
}
