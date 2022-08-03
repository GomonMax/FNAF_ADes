using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLVL : MonoBehaviour
{
    public HeroController HR;
    public int level;


    void Start()
    {
        level = HR.levelToLoad;
    }

    void Update()
    {
        SaveIdLVL();
        level = PlayerPrefs.GetInt("lvlLOAD");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("LVL: " + level);
            SceneManager.LoadScene(0);
        }
    }

    void SaveIdLVL()
    {
        PlayerPrefs.SetInt("lvlLOAD", level);
        PlayerPrefs.Save();
    }
}
