using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FryingRecipeSO
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTime;
}

[CreateAssetMenu()]
public class FryingRecipeListSO : ScriptableObject
{
    public List<FryingRecipeSO> list;

    public bool TryGetFryingRecipe(KitchenObjectSO input, out FryingRecipeSO cuttingRecipe)
    {
        foreach (FryingRecipeSO recipe in list)
        {
            if (recipe.input == input)
            {
                cuttingRecipe = recipe;
                return true;
            }
        }
        cuttingRecipe = null;
        return false;
    }
}
