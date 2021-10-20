using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float velocity = 6;

    void Update()
    {
        gameObject.transform.Translate(new Vector3(velocity, 0, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Debug.Log("test");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Turret"))
        {
            Destroy(gameObject);
        }
    }
}
