using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public enum ScoreType
    {
        Normal = 0,
        Best = 1,
        Line = 2
    }

    public ScoreType scoreType;
    private Text textScore;
    void Start()
    {
        textScore = GetComponent<Text>();
    }

    void Update()
    {
        switch (scoreType)
        {
            case ScoreType.Normal:
                textScore.text = GameManager.Manager.Score.ToString();
                break;
            case ScoreType.Best:
                textScore.text = GameManager.Manager.BestScore.ToString();
                break;
            case ScoreType.Line:
                textScore.text = GameManager.Manager.ScoreList[int.Parse(transform.parent.name) - 1][1];
                break;
        }
        
    }
}
