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
    private bool hasStopFloat;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        hasStopFloat = false;
        SetStartColor();
        StartCoroutine("Float", 0.2f);
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
            if (!hasStopFloat)
            {
                hasStopFloat = true;
                StopCoroutine("Float");
            }

            if (Input.GetMouseButtonDown(0) && !GameManager.Manager.IsOver)
            {
                rigidbody2d.rotation = upAngleSet;
                rigidbody2d.velocity = Vector2.up * upSpeedMax;
                BirdAudio.AudioControl.PlayOneShot(BirdAudio.AudioControl.GetComponent<BirdAudio>().fly, 1);
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Manager.IsOver)
            return;

        if (other.CompareTag("Point"))
        {
            GameManager.Manager.Score++;
            BirdAudio.AudioControl.PlayOneShot(BirdAudio.AudioControl.GetComponent<BirdAudio>().point, 1);
            Destroy(other);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.Manager.IsOver)
            return;

        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Tube"))
        {
            GameManager.Manager.GameOver();
            rigidbody2d.velocity = Vector2.zero;
            animator.speed = 0;
            gameObject.layer = 8;
            BirdAudio.AudioControl.PlayOneShot(BirdAudio.AudioControl.GetComponent<BirdAudio>().hit, 1);
            BirdAudio.AudioControl.PlayOneShot(BirdAudio.AudioControl.GetComponent<BirdAudio>().died, 1);
            dropAngle = 1.5f;

            if (other.gameObject.CompareTag("Ground"))
                rigidbody2d.rotation = -90f;
        }
    }

    private IEnumerator Float(float speed)
    {
        while (true)
        {
            rigidbody2d.velocity = Vector2.down * speed;
            yield return new WaitForSeconds(0.5f);
            rigidbody2d.velocity = Vector2.up * speed;
            yield return new WaitForSeconds(1f);
            rigidbody2d.velocity = Vector2.down * speed;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
