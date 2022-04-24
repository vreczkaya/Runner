using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isRolling;
    private bool isJumping;
    private bool isRunning;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        isJumping = true;
        animator.SetTrigger("jump");
        isJumping = false;
    }

    private void Update()
    {
        isRunning = (!isRolling && !isJumping);
        animator.SetBool("isRunning", isRunning);
    }

    public void Roll()
    {
        isRolling = true;
        animator.SetTrigger("roll");
    }

    public void StopRolling()
    {
        isRolling = false;
    }

    public void TurnToRun()
    {
        animator.SetTrigger("turn");
    }

    public void TurnToIdle()
    {
        animator.SetTrigger("turn");
        animator.SetTrigger("idle");
    }
}
