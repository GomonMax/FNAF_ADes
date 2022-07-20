using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Find : MonoBehaviour
{
    public navAI nav_ai;


    [SerializeField] Transform target;
    [SerializeField] Transform AI;
    [SerializeField] private float distanceRay;
    [SerializeField] private LayerMask objectSelectionMask;

    private Transform m_Transform;
    private Rigidbody2D rb;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    


    void FixedUpdate()
    {
        //float AngleRad = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x);
        //float AngleDeg = (180 / Mathf.PI) * AngleRad;
        //rb.rotation = AngleDeg;


        Ray ray = new Ray(m_Transform.position, m_Transform.forward);
        Debug.DrawRay(m_Transform.position, m_Transform.forward * distanceRay);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, distanceRay, objectSelectionMask))
        {
            transform.position = AI.TransformPoint(0, 0, 1);
        }


    }
}
