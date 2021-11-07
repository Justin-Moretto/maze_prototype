using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlicker : MonoBehaviour
{
    Text text;
    float a = 255;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //a -= Time.deltaTime;
        //text.color = new Color(255, 165, 0, a);
    }
}
