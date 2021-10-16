using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float movementSpeed = 20;
    private float gravity = -5;
    private CharacterController myController = null;
    private Vector3 moveDirection = Vector3.zero;
    void Awake()
    {
        Debug.Log(myController);
        myController = GetComponent<CharacterController>();
        Debug.Log(myController);
    }
    void Update()
    {
        moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Vertical") * movementSpeed, gravity, 0));
        myController.Move(moveDirection * Time.deltaTime);
    }
}
