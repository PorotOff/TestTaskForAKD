using UnityEngine;

public class RemovePickUpableObjectFromPool : MonoBehaviour
{
    private DetectedPickUpdableObjectsPool detectedPickUpdableObjectsPool;

    private void Awake()
    {
        detectedPickUpdableObjectsPool = GetComponent<DetectedPickUpdableObjectsPool>();
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpableObject pickUpableObject = other.GetComponent<PickUpableObject>();

        if (pickUpableObject != null)
        {
            detectedPickUpdableObjectsPool.RemovePickUpableObjectFromPool(pickUpableObject);

            Debug.Log($"PickUpable object rmoved: {pickUpableObject.name}");
        }
    }
}