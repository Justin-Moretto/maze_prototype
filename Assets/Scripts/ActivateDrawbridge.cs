using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDrawbridge : MonoBehaviour
{
    public GameObject drawbridge;
    public GameObject lever;

    private void OnTriggerEnter(Collider other)
    {
        lever.GetComponent<Animator>().SetBool("LeverCanPlay", true);
        Invoke("OpenDrawbridge", 1.8f);
        //TODO: add SFX of lever and drawbridge lowering
    }

    void OpenDrawbridge()
    {
        drawbridge.GetComponent<Animator>().SetBool("Open", true);
    }
}
