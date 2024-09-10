using UnityEngine;

public class NoteTester : MonoBehaviour
{
    public int NoteIndex;
    public NoteType noteType;
    public float FallTime = 1;

    private ScoreManager scoreManager;

    public RectTransform rectTransform;

    private int[] spawnx4k = { -120, -40, 40, 120 };

    private float timeElasped = 0;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        transform.localPosition = new Vector2(getXbyKeyandLanes(noteType), Random.Range(0, 10000));
    }

    float getXbyKeyandLanes(NoteType notetype)
    {
        return notetype switch
        {
            NoteType.Key1 => spawnx4k[0],
            NoteType.Key2 => spawnx4k[1],
            NoteType.Key3 => spawnx4k[2],
            NoteType.Key4 => spawnx4k[3],
            NoteType.FX1 => spawnx4k[0],
            NoteType.FX2 => spawnx4k[0],
            _ => (float)0,
        };
    }
}
