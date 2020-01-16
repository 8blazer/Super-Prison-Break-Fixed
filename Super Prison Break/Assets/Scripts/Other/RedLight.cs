using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
public class RedLight : MonoBehaviour
{
    bool toRed = true;
    public Color color;
    public float colorInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toRed)
        {
            color.r = color.r + Time.deltaTime * 2;
            if (color.r > 2)
            { 
                toRed = false;
            }
        }
        else
        {
            color.r = color.r - Time.deltaTime * 2;
            if (color.r < 1)
            {
                toRed = true;
            }
        }
        gameObject.GetComponent<Light2D>().color = color;
        colorInt = color.r;
    }
}
