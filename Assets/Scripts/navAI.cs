using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] public float distanceRay;
    [SerializeField] private LayerMask objectSelectionMask;
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
    
        RaycastHit2D[] allHits = Physics2D.RaycastAll(transform.position, targetPos, distanceRay, objectSelectionMask);
        for (int i = 0; i < allHits.Length; i++)
        {
            Debug.Log(allHits[i].transform.name);
            agent.SetDestination(target.position);
        }
        RaycastHit2D maskHit = Physics2D.Raycast(transform.position, targetPos, distanceRay, objectSelectionMask);
        if (maskHit.transform != null)
        {
        Debug.Log("Layer object: " + maskHit.transform.name);
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(targetPos), Color.red);

    }
}
