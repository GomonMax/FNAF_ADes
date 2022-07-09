using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject hitEffect;

  void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
       if(transform.position.y > 37 || transform.position.y < -6.2)
       {
          Destroy(gameObject);
       }
    }
}
