using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackpoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public static bool hasWeapon;
    public AudioSource attack;
    public int damage = 50;
    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasWeapon)
        {
            anim.SetTrigger("Swing");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Punch");
        }
    }
    void Attack()
    {
        attack.Play();
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hit)
        {
            enemy.GetComponent<EnemyHp>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}