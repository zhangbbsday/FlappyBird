using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float groundSpeed;
    private const float offsetX = 0.6f;
    private Rigidbody2D rigidbodySelf;

    private void Start()
    {
        rigidbodySelf = GetComponent<Rigidbody2D>();
        rigidbodySelf.velocity = Vector2.left * groundSpeed;
    }
    void Update()
    {
        if (GameManager.Manager.IsOver)
        {
            rigidbodySelf.velocity = Vector2.zero;
            return;
        }

        if (transform.position.x < -offsetX)
            transform.position = new Vector2(offsetX, transform.position.y);
    }
}
