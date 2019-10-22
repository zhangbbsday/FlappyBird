using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Manager.IsOver)
        {
            rigidbody2d.velocity = Vector2.zero;
            return;
        }
        if (rigidbody2d.position.x < -5)
            Destroy(gameObject);
    }

    public void Initialize(float tubeSpeed)
    {
        rigidbody2d.velocity = Vector2.left * tubeSpeed;
    }
}
