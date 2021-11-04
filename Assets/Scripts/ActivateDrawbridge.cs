using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDrawbridge : MonoBehaviour
{
    public GameObject drawbridge;
    public GameObject lever;
    [SerializeField] AudioClip sfx_drawbridge;
    bool audioPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!audioPlayed)
        {
            lever.GetComponent<Animator>().SetBool("LeverCanPlay", true);
            Invoke("OpenDrawbridge", 1.8f);
            gameObject.GetComponent<AudioSource>().PlayOneShot(sfx_drawbridge, 0.6f);
        }
    }

    void OpenDrawbridge()
    {
        drawbridge.GetComponent<Animator>().SetBool("Open", true);
        gameObject.GetComponent<AudioSource>().PlayOneShot(sfx_drawbridge, 0.9f);
    }
}
