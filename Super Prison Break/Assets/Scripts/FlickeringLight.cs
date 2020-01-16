using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
public class FlickeringLight : MonoBehaviour
{
    float timer = 0;
    public float minOnTimer = 0;
    public float maxOnTimer = 0;
    public float minOffTimer = 0;
    public float maxOffTimer = 0;
    bool timerGoing = true;
    bool on = true;
    System.Random rnd = new System.Random();
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > minOnTimer && timerGoing == false && on)
        {
            if (rnd.Next(1, 100) == 1)
            {
                on = false;
                timer = 0;
            }
        }
        else if (timer > minOffTimer && on == false)
        {
            if (rnd.Next(1, 100) == 1)
            {
                on = true;
                timer = 0;
            }
        }
        else if (timer > maxOnTimer && on)
        {
            on = false;
            timer = 0;
        }
        else if (timer > maxOffTimer && on == false)
        {
            on = true;
            timer = 0;
        }
        if (on)
        {
            GetComponent<Light2D>().intensity = 1;
        }
        else
        {
            GetComponent<Light2D>().intensity = 0;
        }
    }
    void FlickerOn()
    {

    }
    void FlickerOff()
    {

    }
}
