using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion: Traps
{
    [SerializeField] private int damage;
    private bool explosion;

    void Update()
    {
        if(CheckAttackDistance())
        {
            animator.SetTrigger("Explosion");
            explosion = true;
        }
        CheckExplosion();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && explosion)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
