using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public int levelLoad;

    void Start()
    {
        if(PlayerPrefs.HasKey("lvlLOAD"))
        {
            levelLoad = PlayerPrefs.GetInt("lvlLOAD");
        }
        if(PlayerPrefs.GetInt("lvlLOAD") == 1)
        {
            PlayerPrefs.SetInt("weaponLOAD", -1);
        }
    }


    public void ContinueM()
    {
        SceneManager.LoadScene(levelLoad);
    }

    public void StartM()
    {
        PlayerPrefs.SetInt("weaponLOAD", -1);
        SceneManager.LoadScene(1);
    }

    public void ExitM()
    {
        Application.Quit();
        Debug.Log("Exit");
    }


}