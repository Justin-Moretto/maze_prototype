using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    private Animator animator;
    private float timer = 0;
    private float displayTime = 1.5f;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("FadeIn"))
        {
            timer = timer + 1 * Time.deltaTime;
        }
        if (timer >= displayTime)
        {
            animator.SetBool("FadeIn", false);
            timer = 0;
        }
    }
}
