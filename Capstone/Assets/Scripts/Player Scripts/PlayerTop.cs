using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTop : MonoBehaviour
{
    [SerializeField] private AnimationClip[] topWalking;
    [SerializeField] private AnimationClip[] topWalkingFront;
    [SerializeField] private AnimationClip[] topWalkingBack;

    [SerializeField] private AnimationClip[] topIdle;
    [SerializeField] private AnimationClip[] topIdleFront;
    [SerializeField] private AnimationClip[] topIdleBack;


    public Animator anim;
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

    //Called by the button sprites in the appearance menu
    public void SetTopAnimation(int i)
    {
        animOverride["Idle"] = topIdle[i];
        animOverride["Idlef"] = topIdleFront[i];
        animOverride["Idleb"] = topIdleBack[i];

        animOverride["Walking"] = topWalking[i];
        animOverride["Walkingf"] = topWalkingFront[i];
        animOverride["Walkingb"] = topWalkingBack[i];
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
