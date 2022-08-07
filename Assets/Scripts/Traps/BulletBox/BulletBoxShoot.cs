using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoxShoot : Shoot
{
    [SerializeField] private Vector3[] targets;
    private int indexTarget;
    private float currentTime;

    void Start()
    {
        CreatePoolBullets();
    }

        void Update()
    {
        Vector3 target = startPoint.position + Target();
        LaunchBullet(target);
    }
    private Vector3 Target()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= delayBetweenShots)
        {
            indexTarget += 1;
            if (indexTarget >= targets.Length)
                indexTarget = 0;
            currentTime = 0;
        }
        return targets[indexTarget];
    }
}
