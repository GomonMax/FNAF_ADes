using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSaveLVL : MonoBehaviour
{
    public int levelLoad;

    void Start()
    {
        if(PlayerPrefs.HasKey("lvlLOAD"))
        {
            levelLoad = PlayerPrefs.GetInt("lvlLOAD");
        }
    }

    void OnMouseDown()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(levelLoad);
        }
    }
}
