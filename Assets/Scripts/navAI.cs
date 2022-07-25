using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] public float distanceRay;
    [SerializeField] private LayerMask objectSelectionMask;
    public EnemyShooting Fire;
    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void FixedUpdate()
    {   
        Vector2 targetPos = target.position - transform.position;
        Vector2 Direction = agent.velocity;
        transform.up = Direction;
        //створив рейкаст
        RaycastHit2D allHits = Physics2D.Raycast(transform.position, targetPos, distanceRay, objectSelectionMask);

        // Якщо ворог бачить гравця, то біжить
        if(allHits.transform == target)
        { 
            agent.SetDestination(target.position);     
            transform.up = targetPos;
            Fire.Shoot();
        }

        RaycastHit2D maskHit = Physics2D.Raycast(transform.position, targetPos, distanceRay, objectSelectionMask);
        
        // Вивід об'єкта, який бачить враг
        if (maskHit.transform != null)
        {
        Debug.Log("Layer object: " + maskHit.transform.name);
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(targetPos), Color.red);
        //Debug.DrawRay(transform.position, transform.TransformDirection(allHits.point), Color.green);

    }
}
