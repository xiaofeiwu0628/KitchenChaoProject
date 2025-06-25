using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    public static event EventHandler OnDrop;
    public static event EventHandler OnPickup;

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

    public void SetKitchenObject(KitchenObject _kitchenObject)
    {
        // 判断是否时为BaseCounter的类
        // 判断是传给柜台还是玩家
        if (kitchenObject != _kitchenObject && _kitchenObject != null && this is BaseCounter)
        {
            OnDrop?.Invoke(this, EventArgs.Empty);
        }
        else if (kitchenObject != _kitchenObject && _kitchenObject != null && this is PlayerController)
        {
            OnPickup?.Invoke(this, EventArgs.Empty);
        }
        kitchenObject = _kitchenObject;
        kitchenObject.transform.localPosition = Vector3.zero;
    }

    public void SetHoldPoint(Transform _holdPoint)
    {
        HoldPoint = _holdPoint;
    }

    public void TransferKitchenObject(KitchenObjectHolder _sourceHolder, KitchenObjectHolder _targetHolder)
    {
        if (_sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("原柜台不存在食材");
            return;
        }

        if (_targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标柜台有食材");
            return;
        }
        _targetHolder.AddKitchenObject(_sourceHolder.GetKitchenObject());
        _sourceHolder.ClearKitchenObject();
    }

    public void AddKitchenObject(KitchenObject _kitchenObject)
    {
        _kitchenObject.transform.SetParent(HoldPoint);
        SetKitchenObject(_kitchenObject);
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public void DestroykitchenObject()
    {
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }

    public void CreateKitchenObject(GameObject _kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(_kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
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

    public static void ClearStaticData()
    {
        OnDrop = null;
        OnPickup = null;
    }
}
