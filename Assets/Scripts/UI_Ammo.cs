using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ammo : MonoBehaviour
{
    public Shooting shoot;
    public WeaponManager WM;
    public Text textAmmo;
    public Text textAmmoMax;
    private int temp = 0;
    void Start()
    {
    }

    void Update()
    {
        textAmmo.text = shoot.ammo.ToString();
        textAmmoMax.text = shoot.maxAmmo.ToString();
    }
}
