using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerPrefs.GetFloat("Stamina");
        if (PlayerPrefs.GetInt("CanGrow") == 1 || PlayerPrefs.GetInt("CanTime") == 1)
        {
            GetComponent<Slider>().enabled = true;
        }
        else
        {
            GetComponent<Slider>().enabled = false;
        }
    }
}
