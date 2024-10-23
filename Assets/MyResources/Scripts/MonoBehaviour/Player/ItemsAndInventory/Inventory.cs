using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] private List<PickUpableItem> InventoryItems = new List<PickUpableItem>();
    [SerializeField] private int maxCapacity = 10;

    public void AddItem(PickUpableItem item)
    {
        if (InventoryItems.Count < maxCapacity)
        {
            InventoryItems.Add(item);

            Debug.Log($"{item.ItemName} placed in inventory");
        }
        else
        {
            throw new UnityException("Inventory has no space");
        }
    }

    public PickUpableItem GetItem(int index)
    {
        if (index >= 0 && index < InventoryItems.Count)
        {
            return InventoryItems[index];
        }

        return null;
    }

    public bool HasAnyItem()
    {
        if (InventoryItems.Count > 0)
        {
            return true;
        }

        return false;
    }
    
    public int GetInventoryItemsCount()
    {
        return InventoryItems.Count;
    }

    public int GetMaxCapacity()
    {
        return maxCapacity;
    }
}