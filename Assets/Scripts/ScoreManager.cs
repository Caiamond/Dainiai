using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;  // 총 점수
    private int combo = 0;  // 콤보

    // 판정 결과에 따라 점수를 추가하는 함수
    public void AddScore(string result)
    {
        switch (result)
        {
            case "Perfect":
                score += 100;
                combo++;
                break;
            case "Good":
                score += 50;
                combo++;
                break;
            case "Bad":
                score += 10;
                combo = 0;  // Bad는 콤보가 끊김
                break;
            case "Miss":
                combo = 0;  // Miss는 콤보가 끊김
                break;
        }

        Debug.Log("현재 점수: " + score + ", 콤보: " + combo);
    }

    // 현재 점수를 반환하는 함수 (UI 표시용)
    public int GetScore()
    {
        return score;
    }

    // 현재 콤보를 반환하는 함수 (UI 표시용)
    public int GetCombo()
    {
        return combo;
    }
}
