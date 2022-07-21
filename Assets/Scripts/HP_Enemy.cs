using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Enemy : MonoBehaviour
{
    public float HP;
    private float damage;
    public GameObject bullet;
    void Awake()
    {
        HP = 100;
        damage = 50;
    }

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            HP -= damage;
        }
    }

    void Update()
    {
       if(HP <= 0)
       {
        Destroy(gameObject);
       } 
    }
}
