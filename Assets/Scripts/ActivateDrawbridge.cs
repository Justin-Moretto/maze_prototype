using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDrawbridge : MonoBehaviour
{
    public GameObject drawbridge;
    public GameObject lever;

    private void OnTriggerEnter(Collider other)
    {
        drawbridge.GetComponent<Animator>().SetBool("Open", true);
        lever.GetComponent<Animator>().SetBool("LeverCanPlay", true);
    }

}
