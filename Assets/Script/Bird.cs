using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    enum StartColor
    {
        Blue = 0,
        Yellow = 1,
        Red = 2
    }
    public float dropAngle;
    public float upAngleSet;

    public float dropSpeed;
    public float upSpeedMax;
    public float dropSpeedMax;

    private StartColor BirdColor { get; set; } = StartColor.Blue;
    private Animator animator;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        SetStartColor();
    }

    private void Update()
    {
        Fly();
    }

    private void SetStartColor()
    {
        BirdColor = (StartColor)Random.Range(0, 3);
        animator.SetTrigger(BirdColor.ToString());
    }

    private void Fly()
    {
        if (GameManager.Manager.IsStart)
        {
            if (GameManager.Manager.IsOver)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                rigidbody2d.rotation = upAngleSet;
                rigidbody2d.velocity = Vector2.up * upSpeedMax;
            }
            else
            {
                if (rigidbody2d.rotation > -90)
                    rigidbody2d.rotation -= dropAngle;
                if (rigidbody2d.velocity.y > -dropSpeedMax)
                    rigidbody2d.velocity += Vector2.down * dropSpeed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GameManager.Manager.GameOver();
            animator.speed = 0;
        }
    }
}
