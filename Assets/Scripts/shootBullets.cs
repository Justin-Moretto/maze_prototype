using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullets : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField]
    float firingSpeed = 500;
    float shotInterval;
    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        shotInterval = 500 / firingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        shotInterval = 500 / firingSpeed; //delete this line for final build. Only here for testing. Only needs to be called in Awake();

        if (timer >= shotInterval)
        {
            Instantiate(bullet, transform.transform);
            timer = 0;
        }
    }
}
