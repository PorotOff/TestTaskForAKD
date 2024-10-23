using UnityEngine;

public class OpenCloseByLBM : MonoBehaviour
{
    [SerializeField] private OpenCloseAnimatorController grafitiGarageOpenCloseAnimatorController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grafitiGarageOpenCloseAnimatorController.SwitchOpenState();
        }
    }
}