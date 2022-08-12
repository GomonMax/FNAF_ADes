using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLVL : MonoBehaviour
{
    public HeroController HR;
    public WeaponManager WM;
    public int level;
    public int weapon;
    public int[] ammunition = new int[2];


    void Start()
    {
        level = HR.levelToLoad;
    }

    void Update()
    {
        PlayerPrefs.SetInt("lvlLOAD", level);
        level = PlayerPrefs.GetInt("lvlLOAD");



        
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
            //SceneManager.LoadScene(0);
        //}
    }
    public void AllValue()
    {
        weapon = WM.currentSelectedWeaponID;
        var weaponO = WM.GetCurrentWeapon();
        ammunition[0] = weaponO.ammo;
        ammunition[1] = weaponO.nowAmmo;
    }

    public void SaveIdLVL()
    {
        AllValue();
        PlayerPrefs.SetInt("weaponLOAD", weapon);
        PlayerPrefs.SetInt("ammoLOAD", ammunition[0]);
        PlayerPrefs.SetInt("nowAmmoLOAD", ammunition[1]);

        PlayerPrefs.Save();
    }
}
