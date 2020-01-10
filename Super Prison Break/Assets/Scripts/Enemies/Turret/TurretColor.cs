using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
public class TurretColor : MonoBehaviour
{
    public Color color;
    GameObject turretLight;
    // Start is called before the first frame update
    void Start()
    {
        turretLight = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Turret.canSee == true)
        {
            color.r = 1;
            color.g = 0;
            turretLight.GetComponent<Light2D>().pointLightOuterRadius = 7;
        }
        else
        {
            color.r = 0;
            color.g = 1;
            turretLight.GetComponent<Light2D>().pointLightOuterRadius = 4;
        }
        GetComponent<SpriteRenderer>().color = color;
        turretLight.GetComponent<Light2D>().color = color;
    }
}
