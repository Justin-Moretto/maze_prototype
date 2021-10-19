using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsMaze2 : MonoBehaviour
{
    private Animator doorsAnimator;

    void Awake()
    {
        doorsAnimator = GetComponent<Animator>();
    }

    void DoorsAnimation()
    {
        doorsAnimator.SetBool("M2DoorLeftOpen", true);
        doorsAnimator.SetBool("M2DoorRightOpen", true);
    }
}