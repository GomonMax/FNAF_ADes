using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BanderaMove : Unit
{
    [Header("Patrol")]
    public Transform[] points;
    private int destenationPoint = 0;
    public float patrolSpeed = 5;

    private NavMeshAgent agent;
    public GameObject deadBody;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //Move();
    }

        //if (points.Length == 0)
        //{
            // Debug.Log("where the points?");
            // return;
        //}

    void FixedUpdate()
    {
        agent.enabled = true;
        Vector2 Direction = agent.velocity;
        transform.up = Direction;
    }

    public void Move()
    {
        for(int i = 0; i < points.Length; i++)
        {
            agent.SetDestination(points[i].position);
        }
    }


}
