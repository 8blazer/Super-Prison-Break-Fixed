using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Activate : MonoBehaviour
{
    public GameObject BossEntrance;
    public GameObject BossSpawner;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && timer > 1)
        {
            timer = 0;
            Destroy(gameObject);
            BossEntrance.SetActive(true);
            BossSpawner.GetComponent<Spawn>().SpawnBoss();
           

        }
    }
}
