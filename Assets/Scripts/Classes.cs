using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class NoteData
{
    public float timing;
    public NoteType noteType;
}

[System.Serializable]
public class ChartData
{
    public List<NoteData> notes = new List<NoteData>();
}

public enum NoteType
{
    Key1,  // 1
    Key2,  // 2
    Key3,  // 3
    Key4,  // 4
    FX1,   // FX1
    FX2    // FX2
}
