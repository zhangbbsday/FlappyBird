using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject startMenu = null;
    [SerializeField]
    private GameObject endMenuFirst = null;
    [SerializeField]
    private GameObject endMenuSecond = null;
    [SerializeField]
    private GameObject endMenuThird = null;
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
    public int BestScore { get; set; } = 0;
    public List<string[]> ScoreList { get; set; } = new List<string[]>();
    private void Awake()
    {
        CsvManager.Instance.CsvCreate(Application.streamingAssetsPath);
    }
    private void Start()
    {
        manager = GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        Screen.SetResolution(450, 800, false);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 50;
    }
    private void Update()
    {
        if (!IsStart && Input.GetMouseButtonDown(0))
            GameStart();
    }
    private void GameStart()
    {
        IsStart = true;
    }

    public void GameOver()
    {
        GetScoreLine();
        BestScore = int.Parse(ScoreList[0][1]);
        IsOver = true;
        score.SetActive(false);

        StartCoroutine(SetMenuActive(endMenuFirst, 0.5f));
        StartCoroutine(SetMenuActive(endMenuSecond, 1.0f));
    }

    public void ShowScoreLine()
    {    
        endMenuFirst.SetActive(false);
        endMenuSecond.SetActive(false);
        endMenuThird.SetActive(true);   
    }

    public IEnumerator SetMenuActive(GameObject menu, float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.Play();
        menu.SetActive(true);
    }

    private void GetScoreLine()
    {
        int score = Score;
        int temp;
        string[] strs = new string[10];

        ScoreList = CsvManager.Instance.ReadCsv(Application.streamingAssetsPath);
        for (int i = 0; i < 10; i++)
        {
            if (ScoreList.Count < i + 1)
                ScoreList.Add(new string[] { (i + 1).ToString(), "0" });

            temp = int.Parse(ScoreList[i][1]);
            if (score >= temp)
            {
                ScoreList[i][1] = score.ToString();
                score = temp;
            }
            strs[i] = ScoreList[i][1];
        }
        CsvManager.Instance.WriteCsv(strs, Application.streamingAssetsPath);
    }
}
