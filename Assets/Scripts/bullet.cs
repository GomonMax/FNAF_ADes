using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public int damage = 10;

  void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);

        Unit unit = collision.collider.GetComponent<Unit>();

        if (unit)
        {
            unit.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

 
}
