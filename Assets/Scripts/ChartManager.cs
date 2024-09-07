using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChartManager : MonoBehaviour
{
    public UnityEvent<int> onNoteHit;

    public GameObject startText;

    public Transform SpawnTransform;
    public GameObject note;
    public List<float> HitTimings = new();
    public List<int> HitNotes = new();

    public bool isRunning = false;

    public float currentTime = 0f;

    private int noteIndex = 0;

    public float startOffset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = -startOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            if (Input.anyKeyDown)
            {
                isRunning = true;
                Destroy(startText);
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            for (int i = noteIndex; i < HitTimings.Count; i++)
            {
                if (HitTimings[i]-1 <= currentTime)
                {
                    Instantiate(note, SpawnTransform);
                    noteIndex = i + 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                int i = 0;
                for (; i < HitTimings.Count; i++)
                {
                    if (HitTimings[i] > currentTime - .3f && !HitNotes.Contains(i))
                    {
                        break;
                    }
                }

                if (Mathf.Abs(currentTime - HitTimings[i]) <= .3f)
                {
                    HitNotes.Add(i);
                    string msg = currentTime - HitTimings[i] < 0 ? "fast" : "late";
                    Debug.Log(msg + (Mathf.Floor((currentTime - HitTimings[i]) * 1000)));
                    onNoteHit.Invoke((int)Mathf.Floor((currentTime - HitTimings[i]) * 1000));
                }
            }
        }
    }
}
