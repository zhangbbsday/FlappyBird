using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float groundSpeed;
    private const float offsetX = 0.5f;
    void Update()
    {
        if (GameManager.Manager.IsOver)
            return;

        if (transform.position.x - groundSpeed < -offsetX)
            transform.position = new Vector2(offsetX, transform.position.y);
        else
            transform.position += Vector3.left * groundSpeed;
    }
}
