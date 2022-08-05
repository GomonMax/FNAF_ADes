using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdWeapon : MonoBehaviour
{
    public LayerMask attackLayer;
    [Header("Params")]
    public int damage = 50;
    public float angle = 45;
    public float rangeAttack = 2;
    public float fireRate = 60;

    [Header("References")]
    public Animator animator;

    private float fireRatePerSeconds;
    private float lastShootTime;

    private bool shootInput;

    //public int damage = 50;
    //public Animator animation;
    //private bool shootInput;
    //public float fireRate = 600;
    //private float fireRatePerSeconds;
    //private float lastShootTime;
    //private bool attack;

    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    attack = false;
    //    Unit unit = collision.gameObject.GetComponent<Unit>();
    //    if(collision.gameObject.CompareTag("AI") && shootInput)
    //    {
    //        if (Time.time > fireRatePerSeconds + lastShootTime)
    //        {
    //            lastShootTime = Time.time;
    //            if (unit)
    //            {
    //               unit.TakeDamage(damage);
    //            }              

    //        }
    //    }
    //}
    //void Update()
    //{
    //    fireRatePerSeconds = 1 / (fireRate / 60);
    //    shootInput = Input.GetButton("Fire1");
    //    animation.SetBool("attack", attack);       

    //}
    private void FixedUpdate()
    {
        fireRatePerSeconds = 1 / (fireRate / 60);

        shootInput = Input.GetButton("Fire1");

        //animator.SetTrigger("attack");

        if (shootInput)
        {
            if (Time.fixedTime > fireRatePerSeconds + lastShootTime)
            {
                animator.SetTrigger("attack");
                Attack();
                lastShootTime = Time.time;
            }

        }

    }

    private void Attack()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, rangeAttack, attackLayer);
       
        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.right, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, attackLayer);

                if (hit)
                {
                    Unit unit = hit.transform.GetComponent<Unit>();

                    if (unit)
                    {
                        unit.TakeDamage(damage);
                    }

                }
            }

        }

    }
#if UNITY_EDITOR //Малювання рейкаста в Dizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        //UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, rangeAttack);

        Vector3 angle01 = Utils.DirectionFromAngle(-transform.eulerAngles.z + 90, -angle / 2);
        Vector3 angle02 = Utils.DirectionFromAngle(-transform.eulerAngles.z + 90, angle / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * rangeAttack);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * rangeAttack);

    }


#endif
}
