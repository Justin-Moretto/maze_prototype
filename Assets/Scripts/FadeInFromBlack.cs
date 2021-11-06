using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFromBlack : MonoBehaviour
{
    Image _blackout;
    float transparency = 1;

    private void Awake()
    {
        _blackout = GetComponent<Image>();
    }

    void Update()
    {
        if (transparency > 0)
        {
            transparency -= Time.deltaTime/5;
            _blackout.color = new Color(0, 0, 0, transparency);
        }
    }
}
