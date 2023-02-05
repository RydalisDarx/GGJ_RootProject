using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI text;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        text.text = slider.value + "/" +  slider.maxValue;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;


        text.text = slider.value + "/" + slider.maxValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
