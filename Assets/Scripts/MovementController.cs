using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 8;
    public float jumpHeight = 2.5f;
    public float gravity = -20;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController character = null;
    private Vector3 velocity;
    private bool isGrounded;

    private Inventory inventory;
    public Vector3 checkpoint;

    void Awake()
    {
        character = GetComponent<CharacterController>();
        inventory = gameObject.GetComponent<Inventory>();
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

        if (character.transform.position.y < -60) Respawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        var collision = other.gameObject.tag;

        if (collision == "MovingPlatform")
        {
            transform.parent = other.transform;
        } else if (collision == "Key")
        {
            inventory.AddKey();
            Destroy(other.gameObject);
            Debug.Log("Key Acquired!");
        } else if (collision == "Door" && inventory.hasKey)
        {
            Destroy(other.gameObject);
        } else if (collision == "Lava")
        {
            Respawn();
        } else if (collision == "Checkpoint")
        {
            checkpoint = character.transform.position;
            Debug.Log("checkpoint reached!");
        }
    }

    private void Respawn()
    {
        transform.position = checkpoint;
        transform.Translate(0, 5, 0);
        transform.parent = null;
    }

    private void OnTriggerExit(Collider other)
    {
            transform.parent = null;
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
