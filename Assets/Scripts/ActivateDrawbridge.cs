using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDrawbridge : MonoBehaviour
{
    public GameObject drawbridge;
    public GameObject lever;

    public void Awake()
    {
        lever.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        drawbridge.SetActive(true);
        //activate drawbridge animation here
    }

    /*public void ActivateLever()
    {
        lever.SetBool("LeverCanPlay");
    }*/
}
