using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public  class BonusParameters
{
    public string tagBonus;
    public int actionTime;
    public int cost;
    public int score;
}

public class GetBonuses : MonoBehaviour
{
    [SerializeField] private List<BonusParameters> bonusParameters = new List<BonusParameters>();
    [SerializeField] private ScoreCounter scoreCounter;

    private PlayerMovement playerMovement;
    private Health health;

    private BonusParameters currentBonus;

    private void Start()
    {
        GetAllComponents();
    }

    /// <summary>
    /// Получает все компоненты
    /// </summary>
    private void GetAllComponents()
    {
        playerMovement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
    }

    /// <summary>
    /// Восполняет несколько здоровья
    /// </summary>
    private void AddHealth()
    {
        health.AddHealth(currentBonus.cost);
    }

    /// <summary>
    /// Ускоряет на некоторое время
    /// </summary>
    /// <param name="actionTime"></param>
    /// <returns></returns>
    private IEnumerator LaunchSpeedUp(float actionTime)
    {
        playerMovement.speedMultiplier = currentBonus.cost;
        yield return new WaitForSeconds(actionTime);
        playerMovement.speedMultiplier = 1;
        yield return null;
    }

    /// <summary>
    /// Даёт неуязвимость на некоторое время
    /// </summary>
    /// <param name="actionTime">Время действия</param>
    /// <returns></returns>
    private IEnumerator LaunchImmortality(float actionTime)
    {
        health.immortality = true;
        yield return new WaitForSeconds(actionTime);
        health.immortality = false;
    }

    /// <summary>
    /// Добавляет очки за поднятие бонуса
    /// </summary>
    private void AddScore()
    {
        scoreCounter.AddScore(currentBonus.score);
    }

    /// <summary>
    /// Обрабатывает касание до других объектов
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var item in bonusParameters)
        {
            if (collision.CompareTag(item.tagBonus))
            {
                currentBonus = item;
            }
        }
        switch (collision.tag)
        {
            case "Heal":
                AddHealth();
                break;
            case "Coin":
                AddScore();
                break;
            case "Immortality":
                StartCoroutine(LaunchImmortality(currentBonus.actionTime));
                break;
            case "SpeedUp":
                StartCoroutine(LaunchSpeedUp(currentBonus.actionTime));
                break;
        }

        //AddScore();

        collision.gameObject.SetActive(false);
    }
}