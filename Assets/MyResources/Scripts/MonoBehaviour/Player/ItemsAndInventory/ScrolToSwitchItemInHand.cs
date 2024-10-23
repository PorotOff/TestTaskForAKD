using UnityEngine;
using UnityEngine.Events;

public class ScrolToSwitchItemInHand : MonoBehaviour
{
    public static UnityEvent<int> OnPlayerScroledItem = new UnityEvent<int>();

    private Inventory inventory;

    private int currentIndex = 0;
    private int maxIndex;

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
    }

    private void Update()
    {
        Scrol();
    }

    private void Scrol()
    {
        float scrolInput = Input.GetAxis("Mouse ScrollWheel");

        maxIndex = inventory.GetInventoryItemsCount() - 1;

        if (maxIndex <= 0)
        {
            return;
        }

        if (scrolInput > 0f)
        {
            currentIndex++;

            if (currentIndex > maxIndex)
            {
                currentIndex = 0;
            }
        }
        else if (scrolInput < 0f)
        {
            currentIndex--;

            if (currentIndex < 0)
            {
                currentIndex = maxIndex;
            }
        }

        OnPlayerScroledItem?.Invoke(currentIndex);
    }
}