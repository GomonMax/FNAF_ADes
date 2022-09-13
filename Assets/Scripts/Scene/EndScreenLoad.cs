using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndScreenLoad : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI completeText;

    void Start()
    {
        level = PlayerPrefs.GetInt("lvlLOAD");
        completeText.text = "Level " + level.ToString() + " Complete";
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            level +=1;
            SceneManager.LoadScene(level);
        }
    }
}
