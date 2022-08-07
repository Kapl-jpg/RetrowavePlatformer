using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : Traps
{
    private AntennaShoot antennaShoot;

    private void Start()
    {
        antennaShoot = GetComponent<AntennaShoot>();
        antennaShoot.character = character;
    }

    void Update()
    {
        antennaShoot.checkAttackDistance = CheckAttackDistance();
        CheckExplosion();
        if (CheckAttackDistance())
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
}