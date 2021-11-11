using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateChest : MonoBehaviour
{
    public GameObject chest;

    private void OnTriggerEnter(Collider other)
    {
        chest.GetComponent<Animator>().SetBool("Open", true);
    }
}
