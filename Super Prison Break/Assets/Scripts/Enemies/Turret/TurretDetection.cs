using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDetection : MonoBehaviour
{
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > .5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.name == "Square123")
            {
                Turret.canSee = true;
                Turret.timer = 0;
            }
            else if (collision.gameObject.name != "TurretBullet")
            {
                Destroy(gameObject);
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.name == "Square123")
            {
                Turret.canSee = true;
                Turret.timer = 0;
            }
            else if (collision.gameObject.name != "TurretBullet")
            {
                Destroy(gameObject);
            }
    }
}
