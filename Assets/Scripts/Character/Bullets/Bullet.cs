using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] protected int damage;
    public Vector3 startPoint { get; set; }
    public Vector3 target { get; set; }
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = (target - startPoint).normalized * speed;
        Vector2 point = Camera.main.WorldToViewportPoint(transform.position);
        if (point.x > 1 || point.x < 0 || point.y > 1 || point.y < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
