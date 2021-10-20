using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullets : MonoBehaviour
{
    public GameObject bullet;

    public float firingSpeed = 500;
    public float projectileSpeed = 6;
    
    float shotInterval;
    float timer;

    void Awake()
    {
        shotInterval = 500 / firingSpeed;
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        shotInterval = 500 / firingSpeed; //delete this line for final build. Only here for testing. Only needs to be called in Awake();

        if (timer >= shotInterval)
        {
            var shot = Instantiate(bullet, transform.transform);
            shot.GetComponent<BulletMove>().velocity = projectileSpeed;
            timer = 0;
        }
    }
}
