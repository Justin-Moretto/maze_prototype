using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float jumpHeight = 3;
    public float gravity = -12;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController character = null;
    private Vector3 velocity;
    private bool isGrounded;

    void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (xMovement != 0 || zMovement != 0)
        {
            Vector3 moveDirection = transform.right * xMovement * moveSpeed + transform.forward * zMovement * moveSpeed;
            character.Move(moveDirection * Time.deltaTime);
        }

        //jumping & falling
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Play around with this, Can you keep track of
        // how many times you enter a trigger and print
        // the total every time?
        Debug.Log("You entered " + other.gameObject.name);

        if (other.gameObject.tag == "MovingPlatform")
        {
            Debug.Log("Parented");
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            Debug.Log("Unparented");
            transform.parent = null;
        }
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
