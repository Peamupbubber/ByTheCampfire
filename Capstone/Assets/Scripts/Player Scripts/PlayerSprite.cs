using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private AnimationClip[] idle;
    [SerializeField] private AnimationClip[] idleBack;
    [SerializeField] private AnimationClip[] idleFront;

    [SerializeField] private AnimationClip[] walking;
    [SerializeField] private AnimationClip[] walkingBack;
    [SerializeField] private AnimationClip[] walkingFront;

    private Animator anim;
    public AnimatorOverrideController animOverride;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        animOverride = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = animOverride;
    }

    public void SetColor(Color newColor)
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }

    //Called by the player preview functions
    public void SetAnimation(int i)
    {
        animOverride["Idle"] = idle[i];
        animOverride["Idleb"] = idleBack[i];
        animOverride["Idlef"] = idleFront[i];

        animOverride["Walking"] = walking[i];
        animOverride["Walkingb"] = walkingBack[i];
        animOverride["Walkingf"] = walkingFront[i];
    }

    public void SetSpriteFlip(bool flip)
    {
        spriteRenderer.flipX = flip;
    }

    public void SetAnimWalking(bool walk)
    {
        anim.SetBool("Walking", walk);
    }

    public void SetAnimDirection(float dir)
    {
        anim.SetFloat("Direction", dir);
    }
}
