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
        //JUMP

    }
    //void Update()
    //{
         
    //    if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    //    {
    //        moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * movementSpeed, gravity, Input.GetAxis("Vertical") * movementSpeed));
    //        myController.Move(moveDirection * Time.deltaTime);
    //    }
    //}
}
