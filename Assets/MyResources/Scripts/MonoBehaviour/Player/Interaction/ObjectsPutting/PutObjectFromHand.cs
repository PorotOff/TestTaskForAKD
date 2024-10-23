using UnityEngine;

public class PutObjectFromHand : MonoBehaviour
{
    private SwitchItemInHand switchItemInHand;
    private IObjectHost objectHost;

    private void Awake()
    {
        switchItemInHand = GetComponent<SwitchItemInHand>();
    }

    private void OnEnable()
    {
        DetectObjectHost.OnObjectHostDetected.AddListener(SetObjectHost);
        DetectObjectHost.OnObjectHostMissed.AddListener(ClearObjectHost);
    }
    private void OnDisable()
    {
        DetectObjectHost.OnObjectHostDetected.RemoveListener(SetObjectHost);
        DetectObjectHost.OnObjectHostMissed.RemoveListener(ClearObjectHost);
    }

    private void Update()
    {
        PutFromHand();
    }

    private void PutFromHand()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject currenHandItem = GetCurrentItemInHand();

            if (currenHandItem != null && objectHost != null)
            {
                objectHost.Place(currenHandItem);

                switchItemInHand.ClearHand();
                RemoveItemFromHand(currenHandItem);
            }
        }
    }

    private void RemoveItemFromHand(GameObject item)
    {
        // Убираем объект из руки
        item.transform.SetParent(null);  // Удаляем из текущей иерархии "руки"
        switchItemInHand.ClearHand();     // Обновляем состояние "руки"
    }

    private GameObject GetCurrentItemInHand()
    {
        foreach (Transform handItem in switchItemInHand.transform)
        {
            GameObject item = handItem.gameObject;
            handItem.SetParent(null);
            return item;
        }
        return null;
    }

    private void SetObjectHost(IObjectHost objectHost)
    {
        this.objectHost = objectHost;
    }
    private void ClearObjectHost()
    {
        objectHost = null;
    }
}