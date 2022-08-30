using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLVL : MonoBehaviour
{
    public GameObject nextlvl;
    public BanderaMove bandera;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bandera"))
        {
            nextlvl.SetActive(true);
            bandera.hp = 999999999;
        }
    }
}
