using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI JudgmentText;
    public TextMeshProUGUI AvgText;

    private ChartManager chartManager;

    private float sum;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        chartManager = FindObjectOfType<ChartManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showJudgement(int judge)
    {
        sum += judge;
        AvgText.text = (sum/++num).ToString();
        JudgmentText.text = judge.ToString();
    }
}
