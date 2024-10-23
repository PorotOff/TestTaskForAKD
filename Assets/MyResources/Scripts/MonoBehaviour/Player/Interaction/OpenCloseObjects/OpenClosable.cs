using UnityEngine;

public abstract class OpenClosable : MonoBehaviour
{
    private bool isOpened = false;

    public void SwitchOpenState()
    {
        if (!isOpened)
        {
            Open();
            isOpened = true;
        }
        else
        {
            Close();
            isOpened = false;
        }
    }

    protected abstract void Open();
    protected abstract void Close();
}