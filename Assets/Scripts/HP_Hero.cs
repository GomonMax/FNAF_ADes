using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP_Hero : MonoBehaviour
{
    public float HP;
    private float damage;
    public GameObject bullet;
    public int levelToLoad;
    void Awake()
    {
        HP = 50000;
        damage = 50;
    }

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "EmemyBullet")
        {
            HP -= damage;
        }
    }

    void Update()
    {
       if(HP <= 0)
       {
        Destroy(gameObject);
        SceneManager.LoadScene(levelToLoad);
       } 
    }
}
