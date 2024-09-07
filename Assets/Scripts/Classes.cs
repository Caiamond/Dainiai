using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class NoteData
{
    public float timing;  // ��Ʈ�� ������ Ÿ�̹� (�� ����)
    public NoteType noteType;  // ��Ʈ�� Ÿ�� (4Ű �Ǵ� FX ��Ʈ)
}

[System.Serializable]
public class ChartData
{
    public List<NoteData> notes = new List<NoteData>();  // ��Ʈ�� ��Ʈ ���
}

public enum NoteType
{
    Key1,  // 1�� Ű
    Key2,  // 2�� Ű
    Key3,  // 3�� Ű
    Key4,  // 4�� Ű
    FX1,   // FX1 (�ϵ� ��Ʈ 1)
    FX2    // FX2 (�ϵ� ��Ʈ 2)
}
