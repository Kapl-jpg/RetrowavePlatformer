using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private Animator animator;
    private GameObject character;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("Player");
    }

    public void Lose()
    {
        animator.SetTrigger("Lose");
        character.GetComponent<GetInput>().gameOver = true;
    }

    public void Win()
    {
        animator.SetTrigger("Win");
        character.GetComponent<GetInput>().gameOver = true;
    }
}
