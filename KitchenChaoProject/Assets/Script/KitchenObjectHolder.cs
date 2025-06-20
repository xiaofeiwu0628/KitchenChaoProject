using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    [SerializeField] private Transform HoldPoint;
    private KitchenObject kitchenObject;

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObject.GetKitchenObjectSO();
    }

    public Transform GetHoldPoint()
    {
        return HoldPoint;
    }

    public void SetKitchenObject(KitchenObject _kitchenobject)
    {
        kitchenObject = _kitchenobject;
        kitchenObject.transform.localPosition = Vector3.zero;
    }

    public void SetHoldPoint(Transform _holdPoint)
    {
        HoldPoint = _holdPoint;
    }

    public void TransferKitchenObject(KitchenObjectHolder sourceHolder, KitchenObjectHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("原柜台不存在食材");
            return;
        }

        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标柜台有食材");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
        sourceHolder.ClearKitchenObject();
    }

    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(HoldPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }

    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }

    public void DestroykitchenObject()
    {
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }

    public void CreateKitchenObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }



    /// <summary>
    /// 判断这个拥有者身上有没有KitchenObject
    /// </summary>
    /// <returns>有返回true，无返回false</returns>
    public bool IsHaveKitchenObject()
    {
        return kitchenObject != null;
    }


}
