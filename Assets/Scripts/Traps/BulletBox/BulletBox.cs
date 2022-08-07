using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBox : Traps
{
    private BulletBoxShoot bulletBoxShoot;

    private void Start()
    {
        bulletBoxShoot = GetComponent<BulletBoxShoot>();
    }

    private void Update()
    {
        CheckExplosion();
    }
}
