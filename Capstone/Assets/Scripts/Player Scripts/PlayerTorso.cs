using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorso : MonoBehaviour
{
    [SerializeField] private AnimationClip[] torsoWalking;
    [SerializeField] private AnimationClip[] torsoWalkingFront;
    [SerializeField] private AnimationClip[] torsoWalkingBack;

    [SerializeField] private AnimationClip[] torsoIdle;
    [SerializeField] private AnimationClip[] torsoIdleFront;
    [SerializeField] private AnimationClip[] torsoIdleBack;


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
    public void SetTorsoAnimation(int i)
    {
        animOverride["Idle"] = torsoIdle[i];
        animOverride["Idlef"] = torsoIdleFront[i];
        animOverride["Idleb"] = torsoIdleBack[i];

        animOverride["Walking"] = torsoWalking[i];
        animOverride["Walkingf"] = torsoWalkingFront[i];
        animOverride["Walkingb"] = torsoWalkingBack[i];
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
