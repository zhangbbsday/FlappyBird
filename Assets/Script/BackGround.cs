using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    public List<Image> images;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        GetBackground();
    }

    private void GetBackground()
    {
        image = images[Random.Range(0, 2)];
    }
}
