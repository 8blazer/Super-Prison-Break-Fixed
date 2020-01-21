using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour
{
    System.Random rnd = new System.Random();
    int i = 0;
    public Text first;
    public Text second;
    public Text third;
    // Start is called before the first frame update
    void Start()
    {
        i = rnd.Next(1, 3);
        if (i == 1)
        {
            PlayerPrefs.SetString("FirstName", "Conner Anderson");
        }
        else if (i == 2)
        {
            PlayerPrefs.SetString("FirstName", "Taran Zorn");
        }
        else
        {
            PlayerPrefs.SetString("FirstName", "Stone Eskelsen");
        }
        PlayerPrefs.SetString("SecondName", PlayerPrefs.GetString("FirstName"));
        while (PlayerPrefs.GetString("SecondName") == PlayerPrefs.GetString("FirstName"))
        {
            i = rnd.Next(1, 3);
            if (i == 1)
            {
                PlayerPrefs.SetString("SecondName", "Conner Anderson");
            }
            else if (i == 2)
            {
                PlayerPrefs.SetString("SecondName", "Taran Zorn");
            }
            else
            {
                PlayerPrefs.SetString("SecondName", "Stone Eskelsen");
            }
        }
        PlayerPrefs.SetString("ThirdName", PlayerPrefs.GetString("FirstName"));
        while (PlayerPrefs.GetString("ThirdName") == PlayerPrefs.GetString("FirstName") || PlayerPrefs.GetString("ThirdName") == PlayerPrefs.GetString("SecondName"))
        {
            i = rnd.Next(1, 3);
            if (i == 1)
            {
                PlayerPrefs.SetString("ThirdName", "Conner Anderson");
            }
            else if (i == 2)
            {
                PlayerPrefs.SetString("ThirdName", "Taran Zorn");
            }
            else
            {
                PlayerPrefs.SetString("ThirdName", "Stone Eskelsen");
            }
        }
        first.text = PlayerPrefs.GetString("FirstName");
        second.text = PlayerPrefs.GetString("SecondName");
        third.text = PlayerPrefs.GetString("ThirdName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
