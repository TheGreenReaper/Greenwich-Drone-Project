using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSTest : MonoBehaviour
{
    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        // Interval ended - update GUI text and start new interval
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            float fps = accum / frames;
            string format = System.String.Format("{0:F2} FPS", fps);

            if (fps > 40 && fps < 50)
                GetComponent<Light>().color = Color.red;
            else if (fps > 50 && fps < 55)
                GetComponent<Light>().color = Color.yellow;
            else if (fps > 55 && fps < 60)
                GetComponent<Light>().color = Color.blue;
            else if (fps > 61)
                GetComponent<Light>().color = Color.green;
            accum = 0.0F;
            frames = 0;
        }
    }
}