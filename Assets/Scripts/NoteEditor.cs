using System.IO;
using UnityEngine;

public class NoteEditor : MonoBehaviour
{
    public GameObject notePrefab;  // ��Ʈ ������ (4Ű ��Ʈ)
    public GameObject fxNotePrefab;  // FX ��Ʈ ������
    public RectTransform noteArea;  // ��Ʈ�� ��ġ�Ǵ� ����
    public AudioSource musicSource;  // ���� ���
    public string savePath = "Assets/Charts/chart.json";  // ��Ʈ ���� ���

    private ChartData chartData = new ChartData();  // ��Ʈ ������

    void Update()
    {
        // 1�� Ű (Key1) - �⺻ ��Ʈ
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaceNote(NoteType.Key1);
        }
        // 2�� Ű (Key2) - �⺻ ��Ʈ
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlaceNote(NoteType.Key2);
        }
        // 3�� Ű (Key3) - �⺻ ��Ʈ
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlaceNote(NoteType.Key3);
        }
        // 4�� Ű (Key4) - �⺻ ��Ʈ
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaceNote(NoteType.Key4);
        }
        // FX1 Ű - �ϵ� ��Ʈ
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaceNote(NoteType.FX1);
        }
        // FX2 Ű - �ϵ� ��Ʈ
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlaceNote(NoteType.FX2);
        }
    }

    // ��Ʈ�� ��ġ�ϴ� �Լ�
    void PlaceNote(NoteType noteType)
    {
        float currentTime = musicSource.time;  // ���� ���� ��� �ð�
        GameObject notePrefabToUse = (noteType == NoteType.FX1 || noteType == NoteType.FX2) ? fxNotePrefab : notePrefab;
        float notePositionX = GetNotePositionX(noteType);

        // ��Ʈ ����
        GameObject newNote = Instantiate(notePrefabToUse, noteArea);
        newNote.GetComponent<RectTransform>().anchoredPosition = new Vector2(notePositionX, 0);

        // ��Ʈ �����Ϳ� Ÿ�ְ̹� ��Ʈ Ÿ�� ����
        chartData.notes.Add(new NoteData { timing = currentTime, noteType = noteType });
        Debug.Log($"{noteType} ��Ʈ ��ġ: {currentTime}��");
    }

    // ��Ʈ Ÿ�Կ� ���� X ��ġ ���� (Ÿ�Ӷ��� �󿡼� �� Ű�� ��ġ�� �°� ��ġ)
    float GetNotePositionX(NoteType noteType)
    {
        switch (noteType)
        {
            case NoteType.Key1: return -300f;  // 1�� Ű ��ġ
            case NoteType.Key2: return -100f;  // 2�� Ű ��ġ
            case NoteType.Key3: return 100f;   // 3�� Ű ��ġ
            case NoteType.Key4: return 300f;   // 4�� Ű ��ġ
            case NoteType.FX1: return -500f;   // FX1 ��Ʈ ��ġ
            case NoteType.FX2: return 500f;    // FX2 ��Ʈ ��ġ
            default: return 0;
        }
    }

    // ��Ʈ �����͸� ���Ϸ� �����ϴ� �Լ�
    public void SaveChart()
    {
        string json = JsonUtility.ToJson(chartData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("��Ʈ ���� �Ϸ�: " + savePath);
    }
}
