using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpHeight = 3.0f;
    public bool isOnGround = false;
    public AudioSource jump;
    int jumpcount = 1;
    public int jumptest = 1;
    Animator anim;
    GameObject attackPoint;
    
    public static int hp;
    //public Text health;


    void Start()
    {
        anim = GetComponent<Animator>();
        hp = 100;
        //health.text = "HEALTH: " + hp;
        attackPoint = gameObject.transform.Find("Attackpoint").gameObject;
    }
    void Update()
    {
        //health.text = "HEALTH: " + hp;
        float movex = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = movex * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && jumptest > 0)
        {
            Jump();
        }
        float x = Input.GetAxisRaw("Horizontal");
        if (x == 0)
        {
            anim.SetInteger("x", 0);
        }
        else
        {
            anim.SetInteger("x", 1);
        }
        if (velocity.y > 0)
        {
            anim.SetInteger("y", 1);
        }
        else if (velocity.y < 0)
        {
            anim.SetInteger("y", -1);
        }
        else
        {
            anim.SetInteger("y", 0);
        }
        if (velocity.x > 0)
        {
            Quaternion transfer = GetComponent<Transform>().rotation;
            transfer.y = 0;
            GetComponent<Transform>().rotation = transfer;

        }
        if (velocity.x < 0)
        {
            Quaternion transfer = GetComponent<Transform>().rotation;
            transfer.y = -180;
            GetComponent<Transform>().rotation = transfer;

        }
        if (hp <= 0)
        {
            anim.SetTrigger("death");
        }
        if (PlayerPrefs.GetString("Size") == "Normal")
        {
            moveSpeed = 5.0f;
            jumpHeight = 3.0f;
            if (PlayerPrefs.GetFloat("Stamina") < 10 && TimeAbility.fakeTimeScale == 1)
            {
                PlayerPrefs.SetFloat("Stamina", PlayerPrefs.GetFloat("Stamina") + Time.deltaTime * 1.5f);
            }
            if (transform.localScale.x < .7f)
            {
                transform.localScale = transform.localScale + new Vector3(.05f, .05f, 0);
            }
            if (transform.localScale.x > .7f)
            {
                transform.localScale = transform.localScale - new Vector3(.05f, .05f, 0);
            }
        }
        else if (PlayerPrefs.GetString("Size") == "Large")
        {
            moveSpeed = 2.5f;
            jumpHeight = 4f;
            PlayerPrefs.SetFloat("Stamina", PlayerPrefs.GetFloat("Stamina") - Time.deltaTime);
            if (PlayerPrefs.GetFloat("Stamina") < .01f)
            {
                PlayerPrefs.SetString("Size", "Normal");
            }
            if (transform.localScale.x < 1.4f)
            {
                transform.localScale = transform.localScale + new Vector3(.05f, .05f, 0);
            }
        }
        else if (PlayerPrefs.GetString("Size") == "Small")
        {
            moveSpeed = 8.0f;
            jumpHeight = 2.0f;
            PlayerPrefs.SetFloat("Stamina", PlayerPrefs.GetFloat("Stamina") - Time.deltaTime);
            if (PlayerPrefs.GetFloat("Stamina") < .01f)
            {
                PlayerPrefs.SetString("Size", "Normal");
            }
            if (transform.localScale.x > .35f)
            {
                transform.localScale = transform.localScale - new Vector3(.05f, .05f, 0);
            }
        }
        if (TimeAbility.fakeTimeScale == .5f)
        {
            PlayerPrefs.SetFloat("Stamina", PlayerPrefs.GetFloat("Stamina") - Time.deltaTime);
            if (PlayerPrefs.GetFloat("Stamina") < .01f)
            {
                TimeAbility.fakeTimeScale = 1;
            }
        }
    }
    public void Jump()
    {
        if (jumptest == jumpcount)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpHeight));
            jumptest -= 1;
        }
        else
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = 0;
            GetComponent<Rigidbody2D>().velocity = velocity;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 75 * jumpHeight));
            jumptest -= 1;
        }
        jump.pitch = 1;
        float pitch = jump.pitch;
        float sounddiffer = Random.Range(-.6f, .7f);
        pitch = pitch + sounddiffer;
        jump.pitch = pitch;
        jump.Play();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 0)
        {
            isOnGround = true;
            anim.SetBool("grounded", true);
            jumptest = jumpcount;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
          if (hp > -1)
          {
            hp = hp - 1;
          }
        }
        if (collision.gameObject.layer == 0)
        {
            isOnGround = true;
            anim.SetBool("grounded", true);
            jumptest = jumpcount;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 0)
        {
            isOnGround = false;
            anim.SetBool("grounded",false);
            jumptest -= 1;
        }
    }
    void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Deathanim()
    {
        anim.SetTrigger("death");
    }
    void TakeDamage()
    {

    }
}
