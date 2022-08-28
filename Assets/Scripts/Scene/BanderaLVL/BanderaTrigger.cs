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
    public GameObject dialog;
    public HeroController hero;

    public AudioSource audio;
    public Music music;

    private bool okInput;
    private bool allow;

    void Update()
    {
        okInput = Input.GetButton("Fire1");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player") && !allow)
        {
            audio.Stop();
            audio.PlayOneShot(music.track2);
            
            dialog.SetActive(true);
            hero.blockMovement = true;

            for(int i = 0; i < triggerSpawn.Length; i++)
            {
                triggerSpawn[i].SetActive(true);
                LampTrue();
            }

            if(okInput)
            {
                slider.SetActive(true);
                bandera.Move();
                dialog.SetActive(false);
                allow = true;
                hero.blockMovement = false;

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
