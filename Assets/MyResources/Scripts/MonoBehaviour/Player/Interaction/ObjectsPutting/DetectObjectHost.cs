using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class DetectObjectHost : MonoBehaviour
{
    public static UnityEvent<IObjectHost> OnObjectHostDetected = new UnityEvent<IObjectHost>();
    public static UnityEvent OnObjectHostMissed = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        IObjectHost objectHost = other.GetComponentInChildren<IObjectHost>();

        if (objectHost != null)
        {
            OnObjectHostDetected?.Invoke(objectHost);
        }

        Debug.Log($"Detected object host: {other.gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        IObjectHost objectHost = other.GetComponentInChildren<IObjectHost>();

        if (objectHost != null)
        {
            OnObjectHostMissed?.Invoke();
        }

        Debug.Log($"Detected object host: {other.gameObject.name}");
    }
}