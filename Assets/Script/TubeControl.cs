using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeControl : MonoBehaviour
{
    public float tubeSpeed;  
    public float interval;
    public List<GameObject> tubes;

    private float createTime;
    private const float startPositionX = 1.92f;  
    private Vector2 startPosition;
    private GameObject tube;

    void Start()
    {
        createTime = 0;
        GetStartColor();
    }

    void Update()
    {
        CreateTube();
    }

    private void GetStartColor()
    {
        tube = tubes[Random.Range(0, 2)];
    }

    private void CreateTube()
    {
        if (Time.time - createTime < interval)
            return;

        if (GameManager.Manager.IsStart && !GameManager.Manager.IsOver)
        {
            startPosition = new Vector2(startPositionX, Random.Range(-3f, -1f));
            Tube t = GameObject.Instantiate(tube, startPosition, Quaternion.identity).GetComponent<Tube>();
            t.Initialize(tubeSpeed);
            createTime = Time.time;
        }
    }
}
