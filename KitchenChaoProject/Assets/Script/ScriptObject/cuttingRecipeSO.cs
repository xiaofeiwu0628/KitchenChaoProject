using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 序列化
[Serializable]
public class cuttingRecipeSO
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
}
[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<cuttingRecipeSO> list;

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
}