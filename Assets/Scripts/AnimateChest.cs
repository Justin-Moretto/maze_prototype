using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateChest : MonoBehaviour
{
    public GameObject chest;
    public AudioClip chestOpen;

    private void OnTriggerEnter(Collider other)
    {
        chest.GetComponent<AudioSource>().PlayOneShot(chestOpen, 0.1f);
        chest.GetComponent<Animator>().SetBool("Open", true);
    }
}
