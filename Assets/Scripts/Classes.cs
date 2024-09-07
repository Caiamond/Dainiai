using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class NoteData
{
    public float timing;  // 노트가 생성될 타이밍 (초 단위)
    public NoteType noteType;  // 노트의 타입 (4키 또는 FX 노트)
}

[System.Serializable]
public class ChartData
{
    public List<NoteData> notes = new List<NoteData>();  // 차트의 노트 목록
}

public enum NoteType
{
    Key1,  // 1번 키
    Key2,  // 2번 키
    Key3,  // 3번 키
    Key4,  // 4번 키
    FX1,   // FX1 (하드 노트 1)
    FX2    // FX2 (하드 노트 2)
}
