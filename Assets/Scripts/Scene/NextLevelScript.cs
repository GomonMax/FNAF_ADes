using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public int levelLoad = 4;      // поки що 4(це сцена з проходженням лвл-ла)
    public SaveLVL save;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player"))
        {
            save.SaveIdLVL();
            SceneManager.LoadScene(levelLoad);
        }
    }
}
