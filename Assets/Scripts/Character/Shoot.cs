using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletParrent;
    [SerializeField] private int bulletsCount;
    [SerializeField] protected float delayBetweenShots;
    [SerializeField] protected Transform startPoint;
    private float timeToShot;
    private Dictionary<GameObject, Bullet> bullets;

    /// <summary>
    /// Создаем пул объектов
    /// </summary>
    public void CreatePoolBullets()
    {
        timeToShot = delayBetweenShots;
        bullets = new Dictionary<GameObject, Bullet>();
        for (int i = 0; i < bulletsCount; i++)
        {
            var instance = Instantiate(bulletPrefab);
            instance.SetActive(false);
            instance.transform.parent = bulletParrent.transform;
            bullets.Add(instance, instance.GetComponent<Bullet>());
        }
    }

    /// <summary>
    /// Получаем снаряд из пула объектов
    /// </summary>
    /// <returns></returns>
    private GameObject GetBulletFromPool(Vector2 target)
    {
        foreach (var instance in bullets)
        {
            if (!instance.Key.activeInHierarchy)
            {
                timeToShot = 0;
                instance.Key.SetActive(true);
                instance.Value.target = target;
                instance.Value.startPoint = startPoint.position;
                instance.Key.transform.position = startPoint.position;
                RotateBullet(instance.Key, target);
                return instance.Key;

            }
        }
        return null;
    }

    /// <summary>
    /// Проверяем может ли стрелять
    /// </summary>
    /// <returns></returns>
    private bool CanShot()
    {
        timeToShot += Time.deltaTime;
        if (timeToShot >= delayBetweenShots)
            return true;

        return false;
    }

    /// <summary>
    /// Запускаем снаряд
    /// </summary>
    /// <param name="direction"></param>
    public void LaunchBullet(Vector2 direction)
    {
        if (CanShot())
            GetBulletFromPool(direction);
    }

    /// <summary>
    /// Задаем поворот снаряду
    /// </summary>
    /// <param name="bullet"></param>
    /// <param name="direction"></param>
    private void RotateBullet(GameObject bullet, Vector2 direction)
    {
        if (direction.x > 0)
            bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}