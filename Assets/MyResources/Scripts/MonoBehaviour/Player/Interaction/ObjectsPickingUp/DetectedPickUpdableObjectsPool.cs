using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectedPickUpdableObjectsPool : MonoBehaviour
{
    private List<PickUpableObject> pickUpableObjectsPool = new List<PickUpableObject>();

    public void AddPickUpableObjectToPool(PickUpableObject pickUpableObject)
    {
        pickUpableObjectsPool.Add(pickUpableObject);
    }
    public void RemovePickUpableObjectFromPool(PickUpableObject pickUpableObject)
    {
        pickUpableObjectsPool.Remove(pickUpableObject);
    }
    public PickUpableObject GetFirstPickUpableObject()
    {
        if (pickUpableObjectsPool.Count <= 0)
        {
            throw new Exception("pickUpableObjectsPool is empty"); 
        }

        return pickUpableObjectsPool[0];
    }
}