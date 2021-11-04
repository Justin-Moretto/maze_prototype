using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    public Component[] Doors;
    public AudioClip sfx_door;

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
        gameObject.GetComponent<AudioSource>().PlayOneShot(sfx_door, 0.8f);
    }
}