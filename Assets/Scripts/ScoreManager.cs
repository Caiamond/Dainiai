using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;  // �� ����
    private int combo = 0;  // �޺�

    // ���� ����� ���� ������ �߰��ϴ� �Լ�
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
                combo = 0;  // Bad�� �޺��� ����
                break;
            case "Miss":
                combo = 0;  // Miss�� �޺��� ����
                break;
        }

        Debug.Log("���� ����: " + score + ", �޺�: " + combo);
    }

    // ���� ������ ��ȯ�ϴ� �Լ� (UI ǥ�ÿ�)
    public int GetScore()
    {
        return score;
    }

    // ���� �޺��� ��ȯ�ϴ� �Լ� (UI ǥ�ÿ�)
    public int GetCombo()
    {
        return combo;
    }
}
