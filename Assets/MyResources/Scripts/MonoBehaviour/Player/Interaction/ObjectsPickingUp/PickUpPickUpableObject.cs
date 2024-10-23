using UnityEngine;
using UnityEngine.Events;

public class PickUpPickUpableObject : MonoBehaviour
{
    public static UnityEvent OnPlayerPickedUpObject = new UnityEvent();

    private Inventory inventory;
    private DetectedPickUpdableObjectsPool detectedPickUpdableObjectsPool;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        detectedPickUpdableObjectsPool = GetComponent<DetectedPickUpdableObjectsPool>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpableObject pickUpableObject = detectedPickUpdableObjectsPool.GetFirstPickUpableObject();

            if (pickUpableObject != null)
            {
                inventory.AddItem(pickUpableObject.pickableItemParameters);

                detectedPickUpdableObjectsPool.RemovePickUpableObjectFromPool(pickUpableObject);

                pickUpableObject.DestroyOnPickedUp();

                OnPlayerPickedUpObject?.Invoke();

                Debug.Log($"Player picked object");
            }
        }
    }
}