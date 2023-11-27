using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegs : MonoBehaviour
{
    [SerializeField] private AnimationClip[] legsWalking;
    [SerializeField] private AnimationClip[] legsWalkingFront;
    [SerializeField] private AnimationClip[] legsWalkingBack;

    [SerializeField] private AnimationClip[] legsIdle;
    [SerializeField] private AnimationClip[] legsIdleFront;
    [SerializeField] private AnimationClip[] legsIdleBack;

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

    public void SetColor(Color newColor) {
        GetComponent<SpriteRenderer>().color = newColor;
    }

    //Called by the button sprites in the appearance menu
    public void SetLegAnimation(int i) {
        animOverride["Idle"] = legsIdle[i];
        animOverride["Idlef"] = legsIdleFront[i];
        animOverride["Idleb"] = legsIdleBack[i];

        animOverride["Walking"] = legsWalking[i];
        animOverride["Walkingf"] = legsWalkingFront[i];
        animOverride["Walkingb"] = legsWalkingBack[i];
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
