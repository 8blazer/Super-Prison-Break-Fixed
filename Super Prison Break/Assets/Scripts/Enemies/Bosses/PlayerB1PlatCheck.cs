using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB1PlatCheck : MonoBehaviour
{
    public static bool PcollidedT;
    public static bool PcollidedG;
    public static bool PcollidedM;
    // Start is called before the first frame update
    void Start()
    {
        PcollidedT = false;
        PcollidedG = false;
        PcollidedM = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Boss1TP":
                PcollidedT = true;
                break;
            case "Boss1MP":
                PcollidedM = true;
                break;
            case "Boss1RP":
                PcollidedG = true;
                break;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Boss1TP":
                PcollidedT = false;
                break;
            case "Boss1LP":
                PcollidedM = false;
                break;
            case "Boss1RP":
                PcollidedG = false;
                break;
        }
    }
}
