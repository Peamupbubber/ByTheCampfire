using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PronounDisplay : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text sliderText;

    [HideInInspector] public int multiplier = 1;
    [HideInInspector] public bool removeClicked = false;

    [HideInInspector] public Character characterInfo;

    public void SetMultiplier() {
        multiplier = (int)slider.value;
        sliderText.text = "" + multiplier;
        characterInfo.pronounsChanged = true;
    }

    public void RemoveClicked() {
        removeClicked = true;
    }
}
