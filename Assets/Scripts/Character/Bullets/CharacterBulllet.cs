using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBulllet : Bullet
{    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            collision.gameObject.GetComponent<Traps>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
