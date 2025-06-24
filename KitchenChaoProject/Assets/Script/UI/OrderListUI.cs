using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OrderListUI : MonoBehaviour
{
    [SerializeField] private Transform recipeParent;
    [SerializeField] private RecipeUI recipeUITemplate;

    private void Start()
    {
        OrderManager.Instance.OnRecipeSpawned += OrderManager_OnRecipeSpawned;
        // OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
    }

    // private void OrderManager_OnRecipeSuccessed(object sender, EventArgs e)
    // {
    //     UpdateUI();
    // }

    private void OrderManager_OnRecipeSpawned(object sender, EventArgs e)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (Transform child in recipeParent)
        {
            if (child != recipeUITemplate)
            {
                Destroy(child.gameObject);
            }
        }

        List<RecipeSO> recipeSOList = OrderManager.Instance.GetOrderRecipeSOList();
        foreach (RecipeSO _recipeSO in recipeSOList)
        {
            RecipeUI recipeUI = GameObject.Instantiate(recipeUITemplate, recipeParent);
            recipeUI.gameObject.SetActive(true);
            recipeUI.UPdateUI(_recipeSO);
        }


    }
}
