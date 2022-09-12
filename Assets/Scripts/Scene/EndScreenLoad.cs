using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenLoad : MonoBehaviour
{
    public int level;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            level = PlayerPrefs.GetInt("lvlLOAD");
            level +=1;
            SceneManager.LoadScene(level);
        }
    }
}
