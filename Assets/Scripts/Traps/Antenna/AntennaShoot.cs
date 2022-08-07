using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaShoot : Shoot
{
    public GameObject character { get; set; }
    public bool checkAttackDistance { get; set; }

    void Start()
    {
        CreatePoolBullets();
    }

    void Update()
    {
        if(checkAttackDistance)
            LaunchBullet(character.transform.position);
    }
}
