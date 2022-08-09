using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFireWeapon : MonoBehaviour
{
    private AudioSource sound;
    public Shooting eventFire;
    public AudioClip audioClip;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(eventFire.hasHit)
        {
            sound.PlayOneShot(audioClip);
            eventFire.hasHit = false;
        }
    }
}
