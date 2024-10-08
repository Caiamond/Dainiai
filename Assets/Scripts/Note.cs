using UnityEngine;

public class Note : MonoBehaviour
{
    public int NoteIndex;
    public NoteType noteType;
    public float FallTime = 1;

    private ScoreManager scoreManager;

    public RectTransform rectTransform;

    private int[] spawnx4k = { -120, -40, 40, 120, -80, 80};

    private float timeElasped = 0;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        transform.localPosition = new Vector2(getXbyKeyandLanes(noteType), 335);
    }

    void Update()
    {
        transform.localPosition = Vector2.Lerp(new Vector2(getXbyKeyandLanes(noteType), 335), new Vector2(getXbyKeyandLanes(noteType), -335), timeElasped / FallTime);
        timeElasped += Time.deltaTime;
        
        if (timeElasped >= FallTime)
        {
            Destroy(gameObject);
        }
    }

    float getXbyKeyandLanes(NoteType notetype)
    {
        return notetype switch
        {
            NoteType.Key1 => spawnx4k[0],
            NoteType.Key2 => spawnx4k[1],
            NoteType.Key3 => spawnx4k[2],
            NoteType.Key4 => spawnx4k[3],
            NoteType.FX1 => spawnx4k[4],
            NoteType.FX2 => spawnx4k[5],
            _ => (float)0,
        };
    }
}
