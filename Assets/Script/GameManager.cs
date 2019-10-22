using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu = null;
    private static GameManager manager;
    public static GameManager Manager
    {
        get
        {
            if (manager == null)
            {
                GameObject obj = new GameObject("GameManager");
                obj.AddComponent<GameManager>();
                manager = obj.GetComponent<GameManager>();
            }
            return manager;
        }
    }
    public bool IsStart { get; private set; } = false;
    public bool IsOver { get; set; } = false;

    private void Start()
    {
        manager = GetComponent<GameManager>();
    }
    private void Update()
    {
        if (!IsStart && Input.GetMouseButtonDown(0))
            GameStart();
    }

    private void GameStart()
    {
        IsStart = true;
        startMenu.SetActive(false);
    }

    public void GameOver()
    {
        IsOver = true;
    }
}
