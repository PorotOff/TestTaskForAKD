using UnityEngine;

public class SwitchItemInHand : MonoBehaviour
{
    private Inventory inventory;
    private Transform playerHandTransform;

    [SerializeField] private bool isImmediatlyPlacePickedUpItemToHand = true;

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
        playerHandTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        PickUpPickUpableObject.OnPlayerPickedUpObject.AddListener(ImmediatlySelect);
        ScrolToSwitchItemInHand.OnPlayerScroledItem.AddListener(SwitchItem);
    }
    private void OnDisable()
    {
        PickUpPickUpableObject.OnPlayerPickedUpObject.AddListener(ImmediatlySelect);
        ScrolToSwitchItemInHand.OnPlayerScroledItem.AddListener(SwitchItem);
    }

    private void SwitchItem(int index)
    {
        ClearHand();

        PickUpableItem newItem = inventory.GetItem(index);

        GameObject newHandObject = Instantiate(newItem.InventoryItemPrefab, playerHandTransform);
        newHandObject.layer = 6;
    }

    private void ImmediatlySelect()
    {
        if (isImmediatlyPlacePickedUpItemToHand)
        {
            int lastPlacedItemNumber = inventory.GetInventoryItemsCount() - 1;

            SwitchItem(lastPlacedItemNumber);
        }
    }

    public void ClearHand()
    {
        foreach (Transform handItem in playerHandTransform)
        {
            Destroy(handItem.gameObject);
        }
    }
}