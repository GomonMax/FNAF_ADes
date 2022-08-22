using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanderaHealthBar : MonoBehaviour
{
    public Slider Slider; 
    public void setHpBar(float curentHp, float maxHp)
    {
        Slider.maxValue = maxHp;
        Slider.value = curentHp;
    }
}
