using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PronounDisplay : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text sliderText;

    public int multiplier = 1;

    public void SetMultiplier() {
        multiplier = (int)slider.value;
        sliderText.text = "" + multiplier;
    }
}
