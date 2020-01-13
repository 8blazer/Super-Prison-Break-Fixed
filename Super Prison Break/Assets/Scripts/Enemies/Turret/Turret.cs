using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public static float timer = 0;
    public static bool timerGoing = false;
    public float direction = 0; //0 = up, 90 = left, 180 = down, -90 = right
    string directionString = "backward";
    public static bool canSee;
    float shootTimer = 0;
    public GameObject sightPrefab;
    public GameObject bulletPrefab;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, direction + 44);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSee == false)
        {
            switch (direction)
            {
                case 90:

                    if (directionString == "forward" && timerGoing == false)
                    {
                        if (TimeAbility.fakeTimeScale == .5f)
                        {
                            transform.Rotate(0, 0, .5f);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 1);
                        }
                        if (transform.rotation.eulerAngles.z >= direction + 45)
                        {
                            timerGoing = true;
                            directionString = "backward";
                        }
                    }
                    else if (directionString == "backward" && timerGoing == false)
                    {
                        if (TimeAbility.fakeTimeScale == .5f)
                        {
                            transform.Rotate(0, 0, -.5f);
                        }
                        else
                        {
                            transform.Rotate(0, 0, -1);
                        }
                        if (transform.rotation.eulerAngles.z <= direction - 45)
                        {
                            timerGoing = true;
                            directionString = "forward";
                        }
                    }

                    break;

                case -90:  //I'm an idiot and can only get it working if the direction is 90 or 180 and now I have to move on

                    if (directionString == "forward" && timerGoing == false)
                    {
                        if (TimeAbility.fakeTimeScale == .5f)
                        {
                            transform.Rotate(0, 0, -.5f);
                        }
                        else
                        {
                            transform.Rotate(0, 0, -1);
                        }
                        if (transform.rotation.eulerAngles.z <= direction - 45)
                        {
                            timerGoing = true;
                            directionString = "backward";
                        }
                    }
                    else if (directionString == "backward" && timerGoing == false)
                    {
                        if (TimeAbility.fakeTimeScale == .5f)
                        {
                            transform.Rotate(0, 0, .5f);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 1);
                        }
                        if (transform.rotation.eulerAngles.z >= direction + 45)
                        {
                            timerGoing = true;
                            directionString = "forward";
                        }
                    }

                    break;

                case 180:

                    if (directionString == "forward" && timerGoing == false)
                    {
                        if (TimeAbility.fakeTimeScale == .5f)
                        {
                            transform.Rotate(0, 0, .5f);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 1);
                        }
                        if (transform.rotation.eulerAngles.z >= direction + 45)
                        {
                            timerGoing = true;
                            directionString = "backward";
                        }
                    }
                    else if (directionString == "backward" && timerGoing == false)
                    {
                        if (TimeAbility.fakeTimeScale == .5f)
                        {
                            transform.Rotate(0, 0, -.5f);
                        }
                        else
                        {
                            transform.Rotate(0, 0, -1);
                        }
                        if (transform.rotation.eulerAngles.z <= direction - 45)
                        {
                            timerGoing = true;
                            directionString = "forward";
                        }
                    }

                    break;
            }
        }
        else
        {
            transform.up = player.transform.position - transform.position;
            timerGoing = true;
            shootTimer += Time.deltaTime;
            if (shootTimer > .3f)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                shootTimer = 0;
                if (TimeAbility.fakeTimeScale == 1)
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.up / 10);
                }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.up / 30);
                }
            }
        }
        if (timerGoing)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                timer = 0;
                canSee = false;
                timerGoing = false;
            }
        }
        GameObject sight = Instantiate(sightPrefab, transform.position, Quaternion.identity);
        sight.GetComponent<Rigidbody2D>().AddForce(transform.up / 14);
    }
}
