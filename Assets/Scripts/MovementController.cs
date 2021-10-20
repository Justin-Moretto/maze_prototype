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
        GameObject _gameObject = other.gameObject;

        switch (_gameObject.tag)
        {
            case "MovingPlatform":
                transform.parent = other.transform;
                break;
            case "Key":
                inventory.AddKey();
                Destroy(_gameObject);
                Debug.Log("Key Acquired!");
                break;
            case "Door":
                if (inventory.hasKey)
                {
                    var door = _gameObject.GetComponent<AnimateDoor>();
                    inventory.UseKey();
                    door.Open();
                    Debug.Log("Key used to open door!");
                }
                break;
            case "Lava":
                Respawn();
                break;
            case "Checkpoint":
                checkpoint = character.transform.position;
                Debug.Log("Checkpoint Reached!");
                break;
            case "Gem":
                inventory.gems++;
                Destroy(_gameObject);
                Debug.Log("Gem Acquired! " + inventory.gems + " / 5");
                break;
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

}
