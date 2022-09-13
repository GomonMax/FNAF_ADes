using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLVL : MonoBehaviour
{
    public GameObject nextlvl;
    public GameObject wall;
    public BanderaMove bandera;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bandera"))
        {
            nextlvl.SetActive(true);
            bandera.hp = 999999999;
            bandera.pipsi = false;
            wall.SetActive(true);         
            animator.SetBool("enable", true);
        }
    }
}
