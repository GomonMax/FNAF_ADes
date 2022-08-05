using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCrash : MonoBehaviour
{
    public GameObject glassSplash;
    public GameObject crackedGlass;
    //private SpriteRenderer spriteR;

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Bullet") || collision.CompareTag("EnemyBullet"))
        {
            GameObject effect = Instantiate(glassSplash, transform.position, transform.rotation);
            //spriteR.sprite = crackedGlass;
        }
    }
}
