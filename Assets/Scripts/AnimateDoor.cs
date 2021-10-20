using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    public Component[] Doors;

    void Awake()
    {
        Doors = GetComponentsInChildren<Animator>();
    }

    public void Open()
    {
       foreach (Animator door in Doors)
        {
            door.SetBool("M2DoorLeftOpen", true);
            door.SetBool("M2DoorRightOpen", true);
        }
    }
}