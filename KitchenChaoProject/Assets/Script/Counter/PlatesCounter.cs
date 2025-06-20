using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO plateSO;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private int plateCountMAX = 5;

    private List<KitchenObject> platesList = new List<KitchenObject>();

    private float timer = 0;

    public override void Interact(PlayerController player)
    {
        if (!player.IsHaveKitchenObject())
        {
            if (platesList.Count > 0)
            {
                player.AddKitchenObject(platesList[platesList.Count - 1]);
                platesList.RemoveAt(platesList.Count - 1);
            }
        }
    }

    private void Update()
    {
        if (plateCountMAX > platesList.Count)
        {
            timer += Time.deltaTime;
            if (timer > spawnRate)
            {
                timer = 0;
                SpawnPlate();
            }
        }
    }

    private void SpawnPlate()
    {
        if (platesList.Count >= plateCountMAX)
        {
            timer = 0;
            return;
        }

        KitchenObject kitchenObject = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();

        kitchenObject.transform.localPosition = Vector3.up * 0.075f * platesList.Count;

        platesList.Add(kitchenObject);
    }
}
