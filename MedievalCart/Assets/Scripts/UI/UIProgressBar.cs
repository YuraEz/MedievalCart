using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UIProgressBar : MonoBehaviour, IScreenListener
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxValue(25);
    }

    void IScreenListener.OnScreenInit()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
}
