using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxBomb(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetBomb(int value)
    {
        slider.value = value;
    }
}
