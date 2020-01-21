using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int maxhealth;
    int currentHealth = 1;
    //public AudioSource hurt;
    public Animator anim;
    public GameObject prisonerPrefab;
    Vector3 velo;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim == null)
            return;
         velo = GetComponent<Rigidbody2D>().velocity;
        if(velo.x < 0)
        {
            anim.SetInteger("x", -1);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (velo.x > 0)
        {
            anim.SetInteger("x", 1);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            anim.SetInteger("x", 0);
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("oog");
        currentHealth -= damage;
       // hurt.pitch = 1;
        //float pitch = hurt.pitch;
        //float sounddiffer = Random.Range(-.5f, .5f);
        //pitch = pitch + sounddiffer;
        //hurt.pitch = pitch;
        //hurt.Play();
        if (currentHealth <= 0)
        {
            GetComponent<Rigidbody2D>().simulated = false;
            if (this.tag == "CellDoor")
            {
                Instantiate(prisonerPrefab, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
                Destroy(gameObject);
            }
            anim.SetTrigger("death");
        }
    }
    public void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

}
