using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public GameObject hero;
    public GameObject camera;

    void Update()
    {
        Vector3 target = new Vector3()
        {
            x = hero.transform.position.x,
            y = hero.transform.position.y,
            z = hero.transform.position.z - 10,
        };
        Vector3 pos = Vector3.Lerp(camera.transform.position, target, speed * Time.fixedDeltaTime);

        camera.transform.position = pos;
    }
}