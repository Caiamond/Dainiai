using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI JudgmentText;

    private ChartManager chartManager;

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
        JudgmentText.text = judge.ToString();
    }
}
