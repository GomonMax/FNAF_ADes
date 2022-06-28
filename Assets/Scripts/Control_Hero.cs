using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Hero : MonoBehaviour
{
    public float speed = 8f;
    public float rotatespeed = 50f;
    public static float vertical, horizontal;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);


        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0 , speed, 0)*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0 , -speed, 0)*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed , 0, 0)*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed , 0, 0)*Time.deltaTime;
        }
        else{}


        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 11.5f;
        }
        else speed = 8f;

    }
}
