using UnityEngine;

public class CharacterShoot : Shoot
{
    public bool shoot { get; set; }
   public Vector3 direction { get; set; }
    private Vector3 target;

    void Start()
    {
        CreatePoolBullets();
    }

    void Update()
    {
        if (shoot)
        {
            target = startPoint.position + direction;
            LaunchBullet(target);
        }
    }
}
