using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GrowShrink : MonoBehaviour
{
    float timer = 0;
    bool timerGoing = false;
    bool canSwitch = true;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Stamina", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("Size") == "Large" && Input.GetKey("s") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Normal");
            timerGoing = true;
        }
        else if (PlayerPrefs.GetString("Size") == "Small" && Input.GetKey("w") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Normal");
            timerGoing = true;
        }
        else if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetFloat("Stamina") > 0 && Input.GetKey("w") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Large");
            timerGoing = true;
            if (SceneManager.GetActiveScene().name == "Level1" && text.text == "W + S to grow and shrink")
            {
                text.text = "";
            }
        }
        else if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetFloat("Stamina") > 0 && Input.GetKey("s") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Small");
            timerGoing = true;
            if (SceneManager.GetActiveScene().name == "Level1" && text.text == "W + S to grow and shrink")
            {
                text.text = "";
            }
        }
        if (timerGoing)
        {
            canSwitch = false;
            timer += Time.deltaTime;
            if (timer > .25f)
            {
                timerGoing = false;
                canSwitch = true;
                timer = 0;
            }
        }
    }
}
