using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlicker : MonoBehaviour
{
    Text text;
    float a = 1;
    bool toggle = true;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a += (toggle ? -1 : 1) * Time.deltaTime;
        text.color = new Color(1, 0.73f, 0, a);
        if (a < 0) toggle = false;
        if (a > 1) toggle = true;
    }
}
