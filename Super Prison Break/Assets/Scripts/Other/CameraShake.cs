using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float timer = 0;
    System.Random rnd = new System.Random();
    public float shake;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CanGrow", 0);
        PlayerPrefs.SetString("Size", "Normal");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3 && timer < 5)
        {
            int i = rnd.Next(1, 5);
            if (i == 1)
            {
                transform.position = transform.position + new Vector3(0, shake, 0);
            }
            else if (i == 2)
            {
                transform.position = transform.position - new Vector3(0, shake, 0);
            }
            else if (i == 3)
            {
                transform.position = transform.position - new Vector3(shake, 0, 0);
            }
            else
            {
                transform.position = transform.position + new Vector3(shake, 0, 0);
            }
        }
    }
}
