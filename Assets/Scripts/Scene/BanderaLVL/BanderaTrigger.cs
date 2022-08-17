using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanderaTrigger : MonoBehaviour
{
    public GameObject[] triggerSpawn;
    void Awake()
    {
        for(int i = 0; i < triggerSpawn.Length; i++)
        {
            triggerSpawn[i].SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player"))
        {
            for(int i = 0; i < triggerSpawn.Length; i++)
            {
                triggerSpawn[i].SetActive(true);
                //bandera.Patrol();
            }
        }
    }
}
