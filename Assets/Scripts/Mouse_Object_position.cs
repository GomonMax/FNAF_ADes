using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Object_position : MonoBehaviour
{
    public GameObject hero;
    public float posx;
    public float posy;
    public float posz;
    void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        posx = (hero.transform.position.x + mousePosition.x)/2;
        posy = (hero.transform.position.y + mousePosition.y)/2;
        posz = (hero.transform.position.z + mousePosition.z)/2;

        transform.position = new Vector3(posx, posy, posz);

    }
}