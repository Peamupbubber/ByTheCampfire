using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    [SerializeField] private AnimationClip[] legs;
    public Animator anim;
    public AnimatorOverrideController animOverride;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animOverride = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = animOverride;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite(int i) {
        Debug.Log("Called with " + i);
        animOverride["Legs_1"] = legs[i];
    }

}
