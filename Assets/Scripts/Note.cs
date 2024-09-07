using UnityEngine;

public class Note : MonoBehaviour
{
    public float fallSpeed = 300f;
    public float noteTiming;
    public NoteType noteType;

    private bool isHit = false;
    private ScoreManager scoreManager;

    public RectTransform rectTransform;

    private int[] spawnx = { -120, -40, 40, 120 };

    private float timeElasped = 0;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        int rn = Random.Range(0, 4);
        transform.localPosition = new Vector2(spawnx[rn], 335);
    }

    void Update()
    {
        transform.localPosition = Vector2.Lerp(new Vector2(transform.localPosition.x, 335), new Vector2(transform.localPosition.x, -335), timeElasped);
        timeElasped += Time.deltaTime;
        
        if (timeElasped >= 1)
        {
            Destroy(gameObject);
        }
    }
}
