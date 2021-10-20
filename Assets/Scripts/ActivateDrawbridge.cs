using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDrawbridge : MonoBehaviour
{
    public GameObject drawbridge;

    private void OnTriggerEnter(Collider other)
    {
        drawbridge.SetActive(true);
        //activate drawbridge animation here
    }
}
