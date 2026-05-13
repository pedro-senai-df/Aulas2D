using UnityEngine;

public class BatAnimator : MonoBehaviour
{
    private Animator animator_;


    private void Start()
    {
        animator_ = GetComponent<Animator>();

        BatBehaviour.Instance.onJump += OnJump;
        BatBehaviour.Instance.onStartFall += OnFall;
    }

    private void OnJump()
    {
        animator_.ResetTrigger("jump");
        animator_.SetTrigger("jump");
    }

    private void OnFall()
    {
        animator_.ResetTrigger("fall");
        animator_.SetTrigger("fall");
    }
}
