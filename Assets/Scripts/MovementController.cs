using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool isJumping = false;

    [SerializeField] AudioClip _footsteps;
    [SerializeField] AudioClip _jump;
    [SerializeField] AudioClip _thud;

    AudioSource Audio;
    void Awake()
    {
        character = GetComponent<CharacterController>();
        transform.rotation = Quaternion.Euler(0, -90, 0);
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (xMovement != 0 || zMovement != 0)
        {
            Vector3 moveDirection = (transform.right * xMovement * moveSpeed) + (transform.forward * zMovement * moveSpeed);
            character.Move(moveDirection * Time.deltaTime);
            if (isGrounded && Audio.isPlaying == false)
            {
                Audio.PlayOneShot(_footsteps, 0.6f);
            } else if (!isJumping && !isGrounded)
            {
                Audio.Stop();
            }
        } else if (xMovement == 0 && zMovement == 0 && !isJumping)
        {
            Audio.Stop();
        }

        //jumping & falling
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if (isJumping)
            {
                Audio.PlayOneShot(_thud, 0.4f);
                isJumping = false;
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            Audio.Stop();
            Audio.PlayOneShot(_jump, 0.2f);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
  
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }


    private void OnTriggerExit(Collider other)
    {
            transform.parent = null;
    }

}
