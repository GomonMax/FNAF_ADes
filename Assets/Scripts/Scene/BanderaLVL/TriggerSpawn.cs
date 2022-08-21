using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject spawner;
    void Awake()
    {
        spawner.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player") || other.gameObject.CompareTag("Bandera"))
        {
            spawner.SetActive(true);
        }
    }
}
