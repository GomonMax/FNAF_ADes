using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdWeapon : MonoBehaviour
{
    public int damage = 50;
    public Animator animation;
    private bool shootInput;
    public float fireRate = 600;
    private float fireRatePerSeconds;
    private float lastShootTime;
    private bool attack;
     
    void OnTriggerStay2D(Collider2D collision)
    {
        attack = false;
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if(collision.gameObject.CompareTag("AI") && shootInput)
        {
            if (Time.time > fireRatePerSeconds + lastShootTime)
            {
                lastShootTime = Time.time;
                if (unit)
                {
                   unit.TakeDamage(damage);
                }              

            }
        }
    }
    void Update()
    {
        fireRatePerSeconds = 1 / (fireRate / 60);
        shootInput = Input.GetButton("Fire1");
        animation.SetBool("attack", attack);       

    }
}
