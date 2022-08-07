using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Traps : MonoBehaviour
{
    protected GameObject character;
    [SerializeField] protected int health;
    [SerializeField] protected float distanceToAttack;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private int score;
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// ��������� �� �����
    /// </summary>
    protected void CheckExplosion()
    {
        if (health <= 0)
            animator.SetTrigger("Explosion");
    }

    /// <summary>
    /// ��������� ��������� �����
    /// </summary>
    /// <returns></returns>
    protected bool CheckAttackDistance()
    {
        float currentDistance = Vector2.Distance(transform.position, character.transform.position);
        return currentDistance <= distanceToAttack;
    }

    /// <summary>
    /// �������� ����
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    protected void DestroyTrap()
    {
        scoreCounter.AddScore(score);
        gameObject.SetActive(false);
    }
}
