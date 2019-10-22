using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float groundSpeed;
    private RectTransform rectTransform;
    private const float offsetX = 24f;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (GameManager.Manager.IsOver)
            return;

        if (rectTransform.localPosition.x - groundSpeed <= -offsetX)
            rectTransform.localPosition = new Vector2(0, rectTransform.localPosition.y);
        else
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x - groundSpeed, rectTransform.localPosition.y);
    }
}
