using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    float timer = 0;
    bool timerGoing = false;
    public float direction = 0; //0 = up, 90 = left, 180 = down, -90 = right
    string directionString = "backward";
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, direction + 45);
    }

    // Update is called once per frame
    void Update()
    {
        if (directionString == "forward" && timerGoing == false)
        {
            transform.Rotate(0, 0, 1);
            if (transform.rotation.eulerAngles.z >= direction + 45)
            {
                timerGoing = true;
                directionString = "backward";
            }
        }
        if (directionString == "backward" && timerGoing == false)
        {
            transform.Rotate(0, 0, -1);
            if (transform.rotation.eulerAngles.z <= direction - 45)
            {
                timerGoing = true;
                directionString = "forward";
            }
        }
        if (timerGoing)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                timer = 0;
                timerGoing = false;
            }
        }
    }
}
