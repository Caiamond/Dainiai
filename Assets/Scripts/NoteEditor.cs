using System.IO;
using UnityEngine;

public class NoteEditor : MonoBehaviour
{
    public GameObject notePrefab;  // 노트 프리팹 (4키 노트)
    public GameObject fxNotePrefab;  // FX 노트 프리팹
    public RectTransform noteArea;  // 노트가 배치되는 영역
    public AudioSource musicSource;  // 음악 재생
    public string savePath = "Assets/Charts/chart.json";  // 차트 저장 경로

    private ChartData chartData = new ChartData();  // 차트 데이터

    void Update()
    {
        // 1번 키 (Key1) - 기본 노트
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaceNote(NoteType.Key1);
        }
        // 2번 키 (Key2) - 기본 노트
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlaceNote(NoteType.Key2);
        }
        // 3번 키 (Key3) - 기본 노트
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlaceNote(NoteType.Key3);
        }
        // 4번 키 (Key4) - 기본 노트
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaceNote(NoteType.Key4);
        }
        // FX1 키 - 하드 노트
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaceNote(NoteType.FX1);
        }
        // FX2 키 - 하드 노트
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlaceNote(NoteType.FX2);
        }
    }

    // 노트를 배치하는 함수
    void PlaceNote(NoteType noteType)
    {
        float currentTime = musicSource.time;  // 현재 음악 재생 시간
        GameObject notePrefabToUse = (noteType == NoteType.FX1 || noteType == NoteType.FX2) ? fxNotePrefab : notePrefab;
        float notePositionX = GetNotePositionX(noteType);

        // 노트 생성
        GameObject newNote = Instantiate(notePrefabToUse, noteArea);
        newNote.GetComponent<RectTransform>().anchoredPosition = new Vector2(notePositionX, 0);

        // 차트 데이터에 타이밍과 노트 타입 저장
        chartData.notes.Add(new NoteData { timing = currentTime, noteType = noteType });
        Debug.Log($"{noteType} 노트 배치: {currentTime}초");
    }

    // 노트 타입에 따라 X 위치 설정 (타임라인 상에서 각 키의 위치에 맞게 배치)
    float GetNotePositionX(NoteType noteType)
    {
        switch (noteType)
        {
            case NoteType.Key1: return -300f;  // 1번 키 위치
            case NoteType.Key2: return -100f;  // 2번 키 위치
            case NoteType.Key3: return 100f;   // 3번 키 위치
            case NoteType.Key4: return 300f;   // 4번 키 위치
            case NoteType.FX1: return -500f;   // FX1 노트 위치
            case NoteType.FX2: return 500f;    // FX2 노트 위치
            default: return 0;
        }
    }

    // 차트 데이터를 파일로 저장하는 함수
    public void SaveChart()
    {
        string json = JsonUtility.ToJson(chartData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("차트 저장 완료: " + savePath);
    }
}
