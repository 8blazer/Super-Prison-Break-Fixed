using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackpoint;
    public float attackRange = .5f;
    public LayerMask PlayerLayers;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, PlayerLayers);
        foreach (Collider2D Player in hit)
        {
            if (Player == null)
                return;
            else
            {
                anim.SetTrigger("Attack");
                GetComponent<RegEnAI>().speed = 0;
            }
        }
    }
    void DoDamage()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, PlayerLayers);
        foreach (Collider2D Player in hit)
        {
            if (Player == null)
                return;
            else
            {
                Player.GetComponent<PlayerMove>().TakeDamage(Damage);
            }
        }
    }
    void Move()
    {
        GetComponent<RegEnAI>().speed = GetComponent<RegEnAI>().regSpeed;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

}
