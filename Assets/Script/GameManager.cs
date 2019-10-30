using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu = null;
    [SerializeField]
    private GameObject endMenuFirst = null;
    [SerializeField]
    private GameObject enbMenuSecond = null;
    [SerializeField]
    private GameObject score = null;

    private static GameManager manager;
    private AudioSource audioSource;
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
    public int Score { get; set; } = 0;
    public int BestScore { get => PlayerPrefs.GetInt("BestScore", 0); }

    private void Start()
    {
        manager = GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        Screen.SetResolution(450, 800, false);
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
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        IsOver = true;
        score.SetActive(false);
        if (bestScore < Score)
            PlayerPrefs.SetInt("BestScore", Score);

        StartCoroutine(SetMenuActive(endMenuFirst, 0.5f));
        StartCoroutine(SetMenuActive(enbMenuSecond, 1.0f));
    }

    public IEnumerator SetMenuActive(GameObject menu, float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.Play();
        menu.SetActive(true);
    }
}
