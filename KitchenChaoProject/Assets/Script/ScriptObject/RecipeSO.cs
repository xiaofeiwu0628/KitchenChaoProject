using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public string recipleName;

    public List<KitchenObjectSO> kitchenObjectSOList;
}


