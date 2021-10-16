using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]private float movementSpeed = 20;
    [SerializeField]private float gravity = -5;
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
         
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * movementSpeed, gravity, Input.GetAxis("Vertical") * movementSpeed));
            myController.Move(moveDirection * Time.deltaTime);
        }
    }
}
