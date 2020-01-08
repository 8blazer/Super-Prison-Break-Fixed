using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAbility : MonoBehaviour
{
    float timer = 0;
    bool timerGoing = false;
    bool canSwitch = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CanTime", 1);
        PlayerPrefs.SetFloat("Stamina", 10);  //Neither of these lines should be in the final game, just testing
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("CanTime") == 1 && Input.GetKeyDown("down") && Time.timeScale == 1)
        {
            Time.timeScale = .5f;
        }
        if (PlayerPrefs.GetInt("CanTime") == 1 && Input.GetKeyDown("up") && Time.timeScale == .5f)
        {
            Time.timeScale = 1f;
        }
    }
}
