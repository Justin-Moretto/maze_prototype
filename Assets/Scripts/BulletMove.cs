using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(5, 0, 0) * Time.deltaTime);
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
