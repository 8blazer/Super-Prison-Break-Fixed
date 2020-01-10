using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB1PlatCheck : MonoBehaviour
{
    public static bool PcollidedT;
    public static bool PcollidedR;
    public static bool PcollidedL;
    // Start is called before the first frame update
    void Start()
    {
        PcollidedT = false;
        PcollidedR = false;
        PcollidedL = false;
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
            case "Boss1LP":
                PcollidedL = true;
                break;
            case "Boss1RP":
                PcollidedR = true;
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
                PcollidedL = false;
                break;
            case "Boss1RP":
                PcollidedR = false;
                break;
        }
    }
}
