using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealthPoint = 100;
    [SerializeField] private ScoreCounter scoreCounter;
    private AnimationController animationController;
    [SerializeField] private EndLevel endLevel;

    public int currentHealthPoint { get; set; }
    public bool immortality { get; set; }

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
        currentHealthPoint = maxHealthPoint;
        ShowHealth();
    }

    public void TakeDamage(int damage)
    {
        currentHealthPoint -= damage;
        ShowHealth();
        animationController.GetHurt();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if(!immortality)
                TakeDamage(5);
        }
        if (!IsAlive())
            endLevel.Lose();
    }

    public void AddHealth(int treatmentPoint)
    {
       currentHealthPoint += treatmentPoint;
        if(currentHealthPoint >= maxHealthPoint)
        {
            currentHealthPoint = maxHealthPoint;
        }
        ShowHealth();
    }

    private bool IsAlive()
    {
        return currentHealthPoint > 0;
    }

    private void ShowHealth()
    {
        scoreCounter.ShowHealth(currentHealthPoint);
    }
}
