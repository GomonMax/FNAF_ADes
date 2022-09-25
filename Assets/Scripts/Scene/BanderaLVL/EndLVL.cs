using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLVL : MonoBehaviour
{
    public GameObject nextlvl;
    public GameObject wall;
    public BanderaMove bandera;
    public Animator animator;
    public GameObject[] spawn;
    public GameObject arrow;
    public GameObject block;
    public GameObject boom;
    //private AudioSource audio;
    //public AudioClip boom;



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bandera"))
        {
            //audio = GetComponent<AudioSource>();
            nextlvl.SetActive(true);
            arrow.SetActive(true);
            block.SetActive(false);
            //audio.PlayOneShot(boom);
            boom.SetActive(true);
            bandera.hp = 999999999;
            bandera.pipsi = false;
            wall.SetActive(true);         
            animator.SetBool("enable", true);

            Spawn();
            gameObject.SetActive(false);
            
        }
    }
    void Spawn()
    {
        for(int i = 0; i < spawn.Length; i++)
        {
            spawn[i].SetActive(false);
        }
    }
}
