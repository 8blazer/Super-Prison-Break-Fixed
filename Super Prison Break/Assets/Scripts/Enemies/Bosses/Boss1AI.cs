using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    public bool activated;
    bool Grown;
    bool Shrunk;

    public Transform player;
    public GameObject GOplayer;

    public float hp;
    float totalHp;

    //Top Platform
    //public Transform Tpoint1;
    //public Transform Tpoint2;
    bool collidedT;

    //Middle Plaform
    //public GameObject MJumpPoint;
    //public GameObject MJumpPoint2;
    //public Transform Lpoint1;
    //public Transform Lpoint2;
    bool collidedM;

    //Ground
    //public GameObject RjumpPoint;
    //public Transform Rpoint1;
    //public Transform Rpoint2;
    bool collidedG;

    float origianlMoveSpeed;
    public float moveSpeed;
    public float jumpHeight;
    public float jumpHeightLeft;

    public float phaseSwitchCheck;
    float phaseTimer;
    public int phase;

    float paceTimer;

    // Start is called before the first frame update
    void Start()
    {
        collidedM = false;
        //collidedR = false;
        collidedT = false;
        Grown = false;
        Shrunk = false;
        totalHp = hp;
        origianlMoveSpeed = moveSpeed;
        phase = 2;

    }

    // Update is called once per frame
    void Update()
    {
        paceTimer += Time.deltaTime;
        phaseTimer += Time.deltaTime;
        //Grow and Shrink Activation
        if (hp < 75 % (totalHp))
        {
            Shrink();
        }
        if (hp < 50 % (totalHp))
        {
            Grow();
        }
        if (hp < 1 % (totalHp))
        {
            Die();
        }
        //Phase Activation
        switch (phase)
        {
            case 1:
                Phase1();
                break;
            case 2:
                Phase2();
                break;
            case 3:
                Phase3();
                break;

        }
        //Phase Switch P1 = Pace P2 = Chase P3 = Run
        if (phaseTimer > phaseSwitchCheck)
        {
            switch (phase)
            {
                case 1:
                    phase = Random.Range(2, 3);
                    break;
                case 2:
                    int random = Random.Range(1, 3);
                    switch (random)
                    {
                        case 1:
                            phase = 1;
                            break;
                        case 2:
                            phase = 1;
                            break;
                    }
                    break;
                case 3:
                    phase = Random.Range(1, 3);
                    break;

            }
            phaseTimer = 0;
        }


    }
    // Check which Platform boss is on
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Boss1TP":
                collidedT = true;
                break;
            case "Boss1MP":
                collidedM = true;
                break;
            case "Boss1RP":
                //collidedR = true;
                break;
            case "Wall":
                moveSpeed *= -1;
                break;

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Boss1TP":
                collidedT = false;
                break;
            case "Boss1MP":
                collidedM = false;
                break;
            case "Boss1RP":
                //collidedR = false;
                break;
        }
    }

   
    // Pace anywhere
    void Phase1()
    {
        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;

        if (collidedM || collidedT)
        {
            // Find closest Edge
            GameObject[] points;
            points = GameObject.FindGameObjectsWithTag("EdgePoint");
            GameObject closestPoint = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject point in points)
            {
                Vector3 diff = point.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closestPoint = point;
                    distance = curDistance;
                }
            }
            // Check if closest edge is close to turn around
            if (Mathf.Abs(closestPoint.transform.position.x - transform.position.x) < .1 && Mathf.Abs(closestPoint.transform.position.y - transform.position.y) < .3
                && paceTimer > .15)
            {
                Debug.Log(paceTimer);
                
                moveSpeed *= -1;
                paceTimer = 0;
            }
        }

    }
    //Chase Player
    void Phase2()
        
    {
        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        // Check  boss and player postions form each other
        float yCheck = player.transform.position.y - transform.position.y;
        //Debug.Log(yCheck);
        float xcheck = transform.position.x - player.transform.position.x;
        
        //If on same platform move towards player
        if (Mathf.Abs(yCheck) < .3)
        {
            
            //Move Boss to player
            if(xcheck < 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed);
            }
            if(xcheck > 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed) * -1;
            }
        }
        //if player above move towards closest jump point
        else if(yCheck > 1.5)
        {
            
            GameObject[] Jpoints;
            Jpoints = GameObject.FindGameObjectsWithTag("JumpPoint");
            GameObject closestPoint = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject Jpoint in Jpoints)
            {
                Vector3 diff = Jpoint.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closestPoint = Jpoint;
                    distance = curDistance;
                }
            }
            float JpointXCheck = closestPoint.transform.position.x - transform.position.x;
            float JpointYCheck = closestPoint.transform.position.y - transform.position.y;
            if (JpointXCheck < 0 && JpointYCheck < .3)
            {
                moveSpeed = Mathf.Abs(moveSpeed) * -1;
            }
            if(JpointXCheck > 0 && JpointYCheck < .3)
            {
                moveSpeed = Mathf.Abs(moveSpeed);
            }
            if (Mathf.Abs(JpointXCheck) < .3 && JpointYCheck < .3)
            {
                GameObject EndJump = closestPoint.transform.Find("EndJump").gameObject;
                float EndCheck = EndJump.transform.position.x - closestPoint.transform.position.y;
                if (EndCheck > 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(100 * jumpHeightLeft, 100 * jumpHeight));
                }
                if(EndCheck < 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-100 * jumpHeightLeft, 100 * jumpHeight));
                }
            }
        }
        //if below drop down

        
    }
    // Run from Player
    void Phase3()
    {
        //Check  boss and player postions form each other
        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        float yCheck = player.transform.position.y - transform.position.y;
        float xcheck = transform.position.x - player.transform.position.x;
        if(Mathf.Abs(yCheck) > .3)
        {
                if (collidedM || collidedT)
                {
                    // Find closest Edge
                    GameObject[] points;
                    points = GameObject.FindGameObjectsWithTag("EdgePoint");
                    GameObject closestPoint = null;
                    float distance = Mathf.Infinity;
                    Vector3 position = transform.position;
                    foreach (GameObject point in points)
                    {
                        Vector3 diff = point.transform.position - position;
                        float curDistance = diff.sqrMagnitude;
                        if (curDistance < distance)
                        {
                            closestPoint = point;
                            distance = curDistance;
                        }
                    }
                    // Check if closest edge is close to turn around
                    if (Mathf.Abs(closestPoint.transform.position.x - transform.position.x) < .3 && Mathf.Abs(closestPoint.transform.position.y - transform.position.y) < .3)
                    {
                        moveSpeed *= -1;
                    }
                }
                //If hitting wall turn around
                if (GetComponent<Rigidbody2D>().velocity.x < (.5 * moveSpeed))
                {
                    moveSpeed *= -1;
                }            
        }
        
    }
    void Grow()
    {
        Shrunk = false;
        Grown = true;
        moveSpeed = 50 % (origianlMoveSpeed);
    }
    void Shrink()
    {
        Shrunk = true;
        moveSpeed = 150 % (origianlMoveSpeed);
    }
    void Die()
    {

    }
}