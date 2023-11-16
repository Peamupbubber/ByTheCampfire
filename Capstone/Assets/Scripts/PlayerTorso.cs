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

    // Start is called before the first frame update
    void Start()
    {
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
}
