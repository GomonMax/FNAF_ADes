using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int numberScene;

    void Start()
    {
        
    }

    void OnTriggerStay2D()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadSceneAsync(numberScene);
        }
    }
    


    void Update()
    {
        OnTriggerStay2D();
    }
}
