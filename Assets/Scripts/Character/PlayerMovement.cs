using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float distanceToGround;
    [Tooltip("Максимальное количество прыжков")]
    [SerializeField] private int numberJumps = 2;
    [SerializeField] private LayerMask layerMask;
    public int speedMultiplier { get; set; } = 1;

    private Rigidbody2D rb;
    private CapsuleCollider2D currentCollider;
    private AnimationController animationController;

    private int numberCurrentJump;
    private bool grounded;
    public bool crouch { get; set; }

    private void GetAllComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        currentCollider = GetComponent<CapsuleCollider2D>();
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        GetAllComponents();
    }

    private void Update()
    {
        CheckGrounded();
        SetAnimation();
    }

    /// <summary>
    /// Передвижение персонажа по земле
    /// </summary>
    /// <param name="horizontalAxis">Нажатие на A/D или влево вправо</param>
    public void Move(float horizontalAxis)
    {
        if (crouch) return;
        float speed = horizontalAxis * runSpeed * speedMultiplier;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    /// <summary>
    /// Прыжок персонажа
    /// </summary>
    public void Jump()
    {
        if (crouch) return;

        if (grounded)
            numberCurrentJump = 0;

        if (numberCurrentJump >= numberJumps)
            return;

        numberCurrentJump++;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Проверка: находится ли персонаж на земле
    /// </summary>
    /// <returns></returns>
    private void CheckGrounded()
    {
        Vector3 originRay = new Vector3(currentCollider.bounds.center.x, currentCollider.bounds.min.y);
        grounded = Physics2D.Raycast(originRay, Vector2.down, distanceToGround, layerMask);
    }

    private void SetAnimation()
    {
        animationController.jump = !grounded;
        animationController.ground = grounded;
    }
}