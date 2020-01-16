using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player(plz)")
        {
            PlayerPrefs.SetInt("Prisoners", PlayerPrefs.GetInt("Prisoners") + 1);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player(plz)")
        {
            PlayerPrefs.SetInt("Prisoners", PlayerPrefs.GetInt("Prisoners") + 1);
            Destroy(gameObject);
        }
    }
}
