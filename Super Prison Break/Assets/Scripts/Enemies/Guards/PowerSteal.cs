using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerSteal : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player(plz)")
        {
            Debug.Log("foo");
            canvas.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown("e"))
            {
                PlayerPrefs.SetInt("CanGrow", 1);
                PlayerPrefs.SetInt("Stamina", 10);
                text.text = "W + S to grow and shrink";
            }
        }
    }
}
