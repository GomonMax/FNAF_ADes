using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackSkreen : MonoBehaviour
{
    public Image image;
    public float colorSpeed = 1f;
    public float maximumSaturation = 0.2f;
    public bool faiding;
    private void Start()
    {
        faiding = true;
    }
    private void Update()
    {
        var color = image.color;

        if (faiding)
        {
            if (color.a >= 0)
            {
                color.a -= colorSpeed * Time.deltaTime;
                image.color = color;
            }
        }

        if (!faiding)
        {
            if (color.a == 1)

            {
                color.a += colorSpeed * Time.deltaTime;
                image.color = color;
                Debug.Log("tyhne");
            }
        }
    }
}
