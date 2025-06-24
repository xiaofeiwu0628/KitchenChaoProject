using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    [SerializeField] private PlateCompleteVisual plateCompleteVisual;
    [SerializeField] private KitchenObjectGridUI kitchenObjectGridUI;

    private List<KitchenObjectSO> kitchenObjectSOList = new List<KitchenObjectSO>();
    public bool AddKitchenObjectSO(KitchenObjectSO _kitchenObjectSO)
    {
        //  如果已经有了
        if (kitchenObjectSOList.Contains(_kitchenObjectSO))
        {
            return false;
        }
        // 如果不是目标食材
        if (validKitchenObjectSOList.Contains(_kitchenObjectSO) == false)
        {
            return false;
        }


        kitchenObjectSOList.Add(_kitchenObjectSO);
        plateCompleteVisual.ShowKitchenObject(_kitchenObjectSO);
        kitchenObjectGridUI.ShowKitchenObjectUI(_kitchenObjectSO);
        return true;
    }

    public List<KitchenObjectSO> GetKitchenObjectSOLIst()
    {
        return kitchenObjectSOList;
    }
}
