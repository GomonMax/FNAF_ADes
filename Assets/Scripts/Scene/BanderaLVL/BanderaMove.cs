using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BanderaMove : MonoBehaviour
{
    [Header("Patrol")]
    public Transform[] points;
    public Transform p;
    private int destenationPoint = 0;
    public float patrolSpeed = 5;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Debug.Log("1: " + transform.rotation.x);
    }

    void FixedUpdate()
    {


        if (points.Length == 0)
        {
            // Debug.Log("where the points?");
            Debug.Log("2: " + transform.rotation.x);

            return;
        }

                    agent.enabled = true;
        Vector2 Direction = agent.velocity;
        Debug.Log("3: " + transform.rotation.x);


        transform.up = Direction;
        Debug.Log("4: " + transform.rotation.x);


        agent.SetDestination(p.position);
        Debug.Log("5: " + transform.rotation.x);
















        //agent.SetDestination(points[destenationPoint].position);
        
    }


}
