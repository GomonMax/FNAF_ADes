using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanderaTrigger : MonoBehaviour
{
    public GameObject[] triggerSpawn;
    public BanderaMove bandera;
    public GameObject slider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player"))
        {
            slider.SetActive(true);
            for(int i = 0; i < triggerSpawn.Length; i++)
            {
                triggerSpawn[i].SetActive(true);
                bandera.Move();

                //bandera.Patrol();
            }
        }
    }
}
