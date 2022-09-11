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
    public float minRemainingDistance = 1.5f;

    private bool pipsi;
    private NavMeshAgent agent;
    public GameObject deadBody;
    public int levelToLoad;
    public BanderaHealthBar healthBar; 
    public GameObject panel;
    public GameObject deadPlayer;
    public SpriteRenderer m_Sprite;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        onDeath.AddListener(Death);
        //Move();
    }
    public void Death(Unit unit)
    {
        var color = m_Sprite.color;
        if (NoiseUnitManager.instance.isAvailable)
        {
            NoiseUnitManager.instance.OnDeath(unit);
        }
        GameObject corp = Instantiate(deadBody, transform.position, transform.rotation);

        if(!deadPlayer.activeSelf)
        {
            panel.SetActive(true);
        }
        //color.a = 0;
        //m_Sprite.color = color;
        //patrolSpeed = 0;
        Destroy(gameObject);

    }
    void FixedUpdate()
    {
        healthBar.setHpBar(hp, maxHP);
        if (pipsi)
        {
            Move();
        }
        agent.enabled = true;
        Vector2 Direction = agent.velocity;
        transform.up = Direction;
    }
    public void Move()
    {
      
        agent.SetDestination(points[destenationPoint].position);
        if (!agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
            destenationPoint = (destenationPoint + 1) % points.Length;
        }
        pipsi = true;

    }


}
