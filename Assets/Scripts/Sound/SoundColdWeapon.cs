using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundColdWeapon : MonoBehaviour
{
    private AudioSource sound;
    public ColdWeapon eventCold;
    public AudioClip audioClip;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(eventCold.hasHit)
        {
            sound.PlayOneShot(audioClip);
            eventCold.hasHit = false;
        }
    }
}
