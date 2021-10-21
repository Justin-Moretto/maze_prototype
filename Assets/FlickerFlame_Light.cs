using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerFlame_Light : MonoBehaviour
{
    [SerializeField]
    private float brightMin = 6f;
    [SerializeField]
    private float brightMax = 10f;
    [SerializeField]
    private int smoothing = 33;
    public Light fireLight;
    Queue<float> smoothQueue;
    private float lastSum = 0;
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    private void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        if (fireLight == null)
        fireLight = GetComponent<Light>();
    }

    private void Update()
    {
        if (fireLight == null)
            return;
        while(smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }
        float newVal = Random.Range(brightMin, brightMax);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        fireLight.intensity = lastSum / (float)smoothQueue.Count;
    }
}