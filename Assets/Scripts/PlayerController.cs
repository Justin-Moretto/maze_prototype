using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float gravity = -5;
    private Vector3 moveDirection = Vector3.zero;
    //ROTATE VARIABLE
    public float rotationSpeed = 90;
    private Vector3 rotationDirection = Vector3.zero;
    //OTHER STUFF
    private CharacterController myController = null;
    


    // Start is called before the first frame update
    void Awake()
    {
        myController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE
        moveDirection = transform.TransformDirection(new Vector3(0, gravity, Input.GetAxis("Vertical") * moveSpeed));
        myController.Move(moveDirection * Time.deltaTime);
        //ROTATE
        rotationDirection = new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
        transform.Rotate(rotationDirection * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        // Play around with this, Can you keep track of
        // how many times you enter a trigger and print
        // the total every time?
        Debug.Log("You entered " + other.gameObject.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name) is great to get more infos
        //This section was used for exercises 6-2 and 6-3
        Debug.Log(collision.collider.name);
        /*
        if (collision.collider.name == "Red Cube")
        {
            Destroy(collision.gameObject);
            Debug.Log("Ouch");
            Debug.Log("You have received 100 dmg.");
            currentHealth -= 100;
        }
        if (collision.collider.name == "Purple Cube")
        {
            Destroy(collision.gameObject);
            Debug.Log("You have received 20 dmg.");
            currentHealth -= 20;
        }*/
    }
}
