using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 序列化
[Serializable]
public class CuttingRecipeSO
{
    public KitchenObjectSO input; 
    public KitchenObjectSO output;
    public int cuttingCountMAX;
}

[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipeSO> list;

    public KitchenObjectSO GetOutput(KitchenObjectSO input)
    {
        foreach (var recipe in list)
        {
            if (recipe.input == input)
            {
                return recipe.output;
            }
        }
        return null;
    }

    public bool TryGetCuttingRecipe(KitchenObjectSO input,out CuttingRecipeSO cuttingRecipe)
    {
        foreach (CuttingRecipeSO recipe in list)
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