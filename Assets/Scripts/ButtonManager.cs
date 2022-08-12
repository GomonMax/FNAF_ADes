using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public int levelToLoad;

    void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerPrefs.SetInt("weaponLOAD", -1);
            SceneManager.LoadScene(levelToLoad);
        }
    }

}