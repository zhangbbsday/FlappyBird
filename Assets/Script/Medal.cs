using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public List<Image> images;

    private Image image;
    private void OnEnable()
    {
        int s;
        image = GetComponent<Image>();
        if (GameManager.Manager.Score > 40)
            s = 3;
        else
            s = GameManager.Manager.Score / 10 - 1;
        if (s >= 0)
            image.sprite = images[s].sprite;
    }
}
