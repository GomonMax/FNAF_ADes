using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bush_Enemy : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if(collision.gameObject.CompareTag("AI"))
        {
            if (enemy)
            {
                enemy.Bush();
            }
        }
    }

}
