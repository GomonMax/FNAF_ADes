using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    [Header("Patrol")]
    public Transform[] points;
    private int destenationToPoint = 0;
    public float minRemainingDistance = 1.5f;
    public float patrolSpeed = 5;

    [Header("Targeting")]
    public GameObject target;
    public string tagOfTarget = "Hero_Player";
    public float timeToDisappear = 2f; //Через скільки секунд втрачає з виду

    [Header("NavMesh")]
    public float ifCantSeeDistance = 2;
    public float ifCanSeeDistance = 6;
    public float standartSpeed = 14;
   
    [Header("Visibility")]
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionlayer;

    [Header("Bash")]
    public float bushTime = 2;

    public bool CanSeePlayer { get => canSeePlayer; }

    private bool canSeePlayer;
    private Shooting shooting;
    private NavMeshAgent agent;

    private Vector3 lastDirection;

    private float appearTimer = 0;
    private bool bush = false;


    public override void Awake()
    {
        base.Awake();
        onDeath.AddListener(Death);
        shooting = GetComponent<Shooting>();
        shooting.useExternalInput = true;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag(tagOfTarget);

            if (!target) Debug.LogError("Dont forget about target");
        }

    }

    private void FixedUpdate()
    {
        FindingFOV();
        Targetering(Time.fixedDeltaTime);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Patrol()
    {
        agent.stoppingDistance = 1;
        agent.speed = patrolSpeed;
        if (points.Length == 0)
        {
            //Debug.Log("where the points?");         
            return;
        }
        if (canSeePlayer == true)
        {
            return;
        }
        Vector2 Direction = agent.velocity;
        transform.up = Direction;
        agent.destination = points[destenationToPoint].position;
        if (!agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
            destenationToPoint = (destenationToPoint + 1) % points.Length;
        }
       // Debug.Log(points[destenationToPoint]);
    }
    public void FindingFOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionlayer))
                {
                    canSeePlayer = false;
                }
                else
                {
                    canSeePlayer = true;
                    if(!bush)
                    {
                        appearTimer = timeToDisappear;
                    }
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else
        {
            canSeePlayer = false;
        }
    }

    public void Targetering(float dt)
    {
        appearTimer = Mathf.Max(appearTimer - dt, 0);
        if(!bush)
        {
            agent.enabled = true;
            if (canSeePlayer)
        {
            shooting.Shoot();           
            agent.stoppingDistance = ifCanSeeDistance;

            Vector2 targetPos = target.transform.position - transform.position;

        }
        else
        {
            agent.stoppingDistance = ifCantSeeDistance;
        }

        if (appearTimer > 0)
        {
            agent.enabled = true;
            agent.speed = standartSpeed;
            if (canSeePlayer)
            {
                Vector2 targetPos = target.transform.position - transform.position;
                transform.up = targetPos;
            }
            else
            {
                Vector2 Direction = agent.velocity;
                transform.up = Direction;
            }

            lastDirection = transform.up;

            agent.SetDestination(target.transform.position);
        }
        else
        {
            Patrol();
        }
        }
        else
        {
            agent.enabled = false;
            if(appearTimer == 0)
            {
                bush = false;
            }
        }
    }

    public void Bush()
    {
        bush = true;
        appearTimer = bushTime;
    }





#if UNITY_EDITOR //Малювання рейкаста в Dizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = Utils.DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = Utils.DirectionFromAngle(-transform.eulerAngles.z, angle / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

        if (CanSeePlayer && Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, target.transform.position);
        }
    }


#endif

}
