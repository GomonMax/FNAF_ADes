using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOL : MonoBehaviour
{
    public GameObject prefab;
    public float radius = 10;

    public float afterLaunch = 100;

    public float fireRate = 60;

    private float fireRatePerSeconds;
    private float lastShootTime;

    public float timer = 15f;

    private void FixedUpdate()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0);

        if (timer != 0) return;

        fireRatePerSeconds = 1 / (fireRate / 60);

        if (Time.time > fireRatePerSeconds + lastShootTime)
        {

            GameObject spawnBot = Instantiate(prefab, transform.position, Random.rotation);
            spawnBot.transform.rotation = Quaternion.Euler(0, 0, spawnBot.transform.eulerAngles.z);
            lastShootTime = Time.time;
        }


    }
}
