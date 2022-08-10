using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public int levelLoad;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player"))
        {
            SceneManager.LoadScene(levelLoad);
        }
    }
}
