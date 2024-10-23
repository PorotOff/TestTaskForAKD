using UnityEngine;

public class AddPickUpableObjectToPool : MonoBehaviour
{
    private DetectedPickUpdableObjectsPool detectedPickUpdableObjectsPool;

    private void Awake()
    {
        detectedPickUpdableObjectsPool = GetComponent<DetectedPickUpdableObjectsPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PickUpableObject pickUpableObject = other.GetComponent<PickUpableObject>();

        if (pickUpableObject != null)
        {
            detectedPickUpdableObjectsPool.AddPickUpableObjectToPool(pickUpableObject);

            Debug.Log($"PickUpable object detected: {pickUpableObject.name}");
        }
    }
}