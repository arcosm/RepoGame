using UnityEngine;

public enum AnimationStates
{
    IDLE,
    RUN,
    WALK,
    SIDE_WALK
}

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation(AnimationStates states)
    {
        switch (states)
        {
            case AnimationStates.IDLE:
                {
                    StopAnimations();
                    animator.SetBool("inIdle", true);
                }
                break;
            case AnimationStates.RUN:
                {
                    StopAnimations();
                    animator.SetBool("inRun", true);
                }
                break;
            case AnimationStates.WALK:
                {
                    StopAnimations();
                    animator.SetBool("inWalk", true);
                }
                break;
            case AnimationStates.SIDE_WALK:
                {
                    StopAnimations();
                    animator.SetBool("inSideWalk", true);
                }
                break;
        }
    }

    public void StopAnimations()
    {
        animator.SetBool("inIdle", false);
        animator.SetBool("inRun", false);
        animator.SetBool("inWalk", false);
        animator.SetBool("inSideWalk", false);

    }
}