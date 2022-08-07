using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(AnimationController))]
[RequireComponent(typeof(CharacterShoot))]
public class GetInput : MonoBehaviour
{
    private CharacterShoot characterShoot;
    private PlayerMovement playerMovement;
    private AnimationController animationController;

    private Vector2 direction;
    private bool clickShoot;

    public bool gameOver { get; set; }

    /// <summary>
    /// Получаем все компоненты
    /// </summary>
    private void GetAllComponents()
    {
        characterShoot = GetComponent<CharacterShoot>();
        playerMovement = GetComponent<PlayerMovement>();
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        direction = new Vector2 (1, 0);
        GetAllComponents();
    }

    private void Update()
    {
        if (gameOver) return;
        TrackInputKeyboard();
        PassAnimationValues();
    }

    /// <summary>
    /// Отследить ввод с клавиатуры
    /// </summary>
    private void TrackInputKeyboard()
    {
        float horizontalAxis = Input.GetAxis(Constants.HORIZONTAL_AXIS);
        float verticalAxis = Input.GetAxisRaw(Constants.VERTIACAL_AXIS);

        playerMovement.Move(horizontalAxis);

        bool crouch = verticalAxis < 0;
        playerMovement.crouch = crouch;

        CharacterRotation(Direction(horizontalAxis));
        InputShoot(horizontalAxis);
        InputJump();
    }

    #region GetInputs

    /// <summary>
    /// Направление движения
    /// </summary>
    /// <param name="horizontalAxis">Ось по горизонтали</param>
    /// <returns></returns>
    private Vector2 Direction(float horizontalAxis)
    {
        if (horizontalAxis > 0)
            direction = new Vector2(1,0);
        else if (horizontalAxis < 0)
            direction = new Vector2(-1, 0);        
        return direction;
    }

    /// <summary>
    /// Стрельба
    /// </summary>
    /// <param name="horizontalAxis">Ось по горизонтали</param>
    private void InputShoot(float horizontalAxis)
    {
        if (Input.GetMouseButtonDown(0))
            clickShoot = true;
        else if (Input.GetMouseButtonUp(0))
            clickShoot = false;

        if (clickShoot)
        {
            characterShoot.direction = Direction(horizontalAxis);
            characterShoot.shoot = true;
        }
        else
            characterShoot.shoot = false;
    }

    /// <summary>
    /// Поворот персонажа
    /// </summary>
    private void CharacterRotation(Vector2 direction)
    {
        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    /// <summary>
    /// Прыжок
    /// </summary>
    private void InputJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            playerMovement.Jump();
    }

    #endregion

    #region AnimationValues

    /// <summary>
    /// Объединяем все значения для анимации
    /// </summary>
    private void PassAnimationValues()
    {
        SetRunAnimation();
        SetShootAnimation();
        SetCrouchAnimation();
    }

    /// <summary>
    /// Устанавливаем анимацию бега
    /// </summary>
    private void SetRunAnimation()
    {
        float horizontalAxisRaw = Input.GetAxisRaw(Constants.HORIZONTAL_AXIS);
        animationController.speed = (int)horizontalAxisRaw;
    }

    /// <summary>
    /// Устанавливаем анимацию стрельбы
    /// </summary>
    private void SetShootAnimation()
    {
        animationController.shoot = clickShoot;
    }

    /// <summary>
    /// Устанавливаем анимацию приседания
    /// </summary>
    private void SetCrouchAnimation()
    {
        float verticalAxis = Input.GetAxisRaw(Constants.VERTIACAL_AXIS);
        if ((int)verticalAxis < 0)
            animationController.crouch = true;
        else
            animationController.crouch = false;
    }

    #endregion
}