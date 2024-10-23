using UnityEngine;

[CreateAssetMenu(fileName = "PickUpableItem", menuName = "Inventory/PickUpableItem", order = 1)]
public class PickUpableItem : ScriptableObject
{
    public string ItemName;

    public GameObject InventoryItemPrefab;
    public GameObject WorldObjectPrefab;
    
    public float SphereColliderRadius = 1f;
    public bool IsSphereColliderTrigger = true;
}