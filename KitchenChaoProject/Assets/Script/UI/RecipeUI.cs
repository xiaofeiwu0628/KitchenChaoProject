using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeleNameText;
    [SerializeField] private Transform kitchenObjectParent;
    [SerializeField] private Image iconUITemplate;

    private void Start()
    {
        iconUITemplate.gameObject.SetActive(false);
    }

    public void UPdateUI(RecipeSO _recipeSO)
    {
        recipeleNameText.text = _recipeSO.recipleName;
        foreach (KitchenObjectSO _kitchenObjectSO in _recipeSO.kitchenObjectSOList)
        {
            Image newIcon = GameObject.Instantiate(iconUITemplate, kitchenObjectParent);
            newIcon.sprite = _kitchenObjectSO.sprite;
            newIcon.gameObject.SetActive(true);
        }
    }
}
