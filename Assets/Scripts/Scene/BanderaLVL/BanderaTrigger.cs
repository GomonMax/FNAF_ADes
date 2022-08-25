using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanderaTrigger : MonoBehaviour
{
    public GameObject[] triggerSpawn;
    public GameObject[] lamp;

    public BanderaMove bandera;
    public GameObject slider;

    public bool allow;

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player"))
        {
            slider.SetActive(true);
            bandera.Move();
            allow = true;

            for(int i = 0; i < triggerSpawn.Length; i++)
            {
                triggerSpawn[i].SetActive(true);
                LampTrue();
            }
        }
    }

    void LampTrue()
    {
        for(int i = 0; i < lamp.Length; i++)
        {
            lamp[i].SetActive(true);
        }
    }
}
