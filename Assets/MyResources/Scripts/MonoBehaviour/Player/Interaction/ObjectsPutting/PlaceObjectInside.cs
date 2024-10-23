using UnityEngine;

public class PlaceObjectInside : MonoBehaviour, IObjectHost
{
    private Transform placesForPlaceableObjectContainer;

    private void Awake()
    {
        placesForPlaceableObjectContainer = GetComponent<Transform>();
    }

    public void Place(GameObject placeableObject)
    {
        int placesCount = placesForPlaceableObjectContainer.childCount;
        int randomPlaceIndex = Random.Range(0, placesCount);

        Transform placesContainerChild = placesForPlaceableObjectContainer.GetChild(randomPlaceIndex);

        placeableObject.transform.SetParent(placesContainerChild);
        placeableObject.transform.localPosition = Vector3.zero;
        placeableObject.transform.localRotation = Quaternion.identity;
        placeableObject.layer = 0;

        Collider objectCollider = placeableObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
    }
}