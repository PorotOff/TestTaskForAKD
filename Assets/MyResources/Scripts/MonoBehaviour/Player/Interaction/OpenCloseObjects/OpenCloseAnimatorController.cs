using UnityEngine;

public class OpenCloseAnimatorController : OpenClosable
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void Open()
    {
        animator.SetBool("IsOpen", true);
    }
    protected override void Close()
    {
        animator.SetBool("IsOpen", false);
    }
}