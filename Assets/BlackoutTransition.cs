using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutTransition : MonoBehaviour
{
    SpriteRenderer _blackout;
    float transparency = 0;
    bool fadeIn = false;

    void Awake()
    {
        _blackout = GetComponent<SpriteRenderer>();    
    }

    public void Play()
    {
        fadeIn = true;
    }

    private void Update()
    {
        if (fadeIn || !fadeIn && transparency > 0)
        {
            transparency += (fadeIn ? 3f : -1.5f) * Time.deltaTime;
            Debug.Log("transparency: " + transparency);
            _blackout.color = new Color(0, 0, 0, transparency);
        }

        if (_blackout.color.a >= 2) fadeIn = false;
    }
}
