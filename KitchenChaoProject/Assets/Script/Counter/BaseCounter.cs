using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectCounter;
    virtual public void Interact(PlayerController player)
    {
        Debug.LogWarning(this.gameObject + "没有重写Interact方法");
    }

    virtual public void InteractOperate(PlayerController player)
    {
        
    }

    public void SelectCounter()
    {
        selectCounter.SetActive(true);
    }

    public void CancelSelect()
    {
        selectCounter.SetActive(false);
    }
}
