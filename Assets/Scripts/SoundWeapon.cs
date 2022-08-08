using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWeapon : MonoBehaviour
{
    private AudioSource sound;
    public ColdWeapon eventCold;
    public Shooting eventFire;
    public AudioClip audioClip;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(eventCold.hasHit || eventFire.hasHit)
        {
            sound.PlayOneShot(audioClip);
            eventCold.hasHit = false;
            eventFire.hasHit = false;
        }
    }
}
