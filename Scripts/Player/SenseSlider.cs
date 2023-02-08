using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenseSlider : MonoBehaviour
{
    public Slider slider;
    public int SliderValue;


    public void SetSenseInitial(int sense)
    {
        slider.maxValue = sense;
        slider.minValue = 0;
        slider.value = sense;
        slider.wholeNumbers = true;

    }

    public void SetSense()
    {
        SliderValue = (int)slider.value;


    }
}
