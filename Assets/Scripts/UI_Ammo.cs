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
        Debug.Log(WM.currentSelectedWeaponID);
        if(WM.currentSelectedWeaponID == -1)
        {       
            //Debug.Log("KAKAKAKAKAK" + WM.HasWeapon());

        }
        else
        {
            textAmmo.text = shoot.ammo.ToString() + " / " + shoot.maxAmmo.ToString();
            //Debug.Log(WM.HasWeapon());
        }
        //Debug.Log(WM.currentSelectedWeaponID);
            
    }
}
