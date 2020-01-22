using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAbility : MonoBehaviour
{
    public static float fakeTimeScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CanTime", 0);
        PlayerPrefs.SetFloat("Stamina", 10);  //Neither of these lines should be in the final game, just testing
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("CanTime") == 1 && Input.GetKeyDown("down"))
        {
            fakeTimeScale = .5f;
        }
        if (PlayerPrefs.GetInt("CanTime") == 1 && Input.GetKeyDown("up"))
        {
            fakeTimeScale = 1f;
        }
    }
}
