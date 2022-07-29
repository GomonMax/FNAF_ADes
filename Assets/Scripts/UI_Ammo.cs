using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ammo : MonoBehaviour
{
    public Shooting shoot;
    public WeaponManager WM;
    public Text textAmmo;
    void Start()
    {
    }

    void FixedUpdate()
    {
        //Debug.Log(WM.currentSelectedWeaponID);
        if(WM.currentSelectedWeaponID == -1)
        {       
           Debug.Log( " true " + WM.currentSelectedWeaponID);
            textAmmo.text = "0";
        }
        else
        {
            Debug.Log(" false " + WM.currentSelectedWeaponID);
            textAmmo.text = shoot.ammo.ToString() + " / " + shoot.maxAmmo.ToString();
            //Debug.Log(WM.HasWeapon());
        }
        //Debug.Log(WM.currentSelectedWeaponID);
            
    }
}
