using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class ChartManager : MonoBehaviour
{
    public UnityEvent<int> onNoteHit;

    public string chartFilePath = "Assets/Charts/chart.json";

    public float NoteFallTime = 1;

    public AudioSource song;
    public GameObject startText;
    public Transform SpawnTransform;
    public GameObject note;
    public GameObject fxnote;
    public ChartData HitTimings = new();
    public List<int> HitNotes = new();

    public bool isRunning = false;

    public float currentTime = 0f;

    private List<GameObject> Notes = new();
    private int noteIndex = 0;

    public float startOffset = 2f;
    
    void LoadChart()
    {
        if (File.Exists(chartFilePath))
        {
            string json = File.ReadAllText(chartFilePath);
            HitTimings = JsonUtility.FromJson<ChartData>(json);
            Debug.Log("ChartLoaded. Number of notes: " + HitTimings.notes.Count);
        }
        else
        {
            Debug.LogError("No chart?");
        }
    }
    // Start is called before the first frame update

    void setto160random()
    {
        for (int i = 0; i < 321; i++)
        {
            NoteData noteData = new()
            {
                timing = i * 375 / 2
            };
            int rn = Random.Range(0, 4);
            switch (rn)
            {
                case 0:
                    noteData.noteType = NoteType.Key1;
                    break;
                case 1:
                    noteData.noteType = NoteType.Key2;
                    break;
                case 2:
                    noteData.noteType = NoteType.Key3;
                    break;
                case 3:
                    noteData.noteType = NoteType.Key4;
                    break;
            }

            HitTimings.notes.Add(noteData);
        }
    }
    void Start()
    {
        //HitTimings = new();
        LoadChart();
        for (int i = 0; i < HitTimings.notes.Count; i++)
        {
            HitTimings.notes[i].timing /= 1000f;
        }
        currentTime = -startOffset;
    }

    List<NoteType> GetLanePressed()
    {
        List<NoteType> pressed = new();
        if (Input.GetKeyDown(KeyCode.S))
        {
            pressed.Add(NoteType.Key1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pressed.Add(NoteType.Key2);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            pressed.Add(NoteType.Key3);
        }
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            pressed.Add(NoteType.Key4);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed.Add(NoteType.FX1);
        }
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            pressed.Add(NoteType.FX2);
        }
        return pressed;
    }

    void CalculateNoteHit(NoteType key)
    {
        int i = 0;
        for (; i < HitTimings.notes.Count; i++)
        {
            if (HitTimings.notes[i].timing > currentTime - .25f && !HitNotes.Contains(i) && HitTimings.notes[i].noteType == key)
            {
                break;
            }
        }

        if (Mathf.Abs(currentTime - HitTimings.notes[i].timing) <= .25f)
        {
			switch (currentTime - HitTimings.notes[i].timing)
			{
				case <= 0.05f:
					Debug.Log("Perfect!!");
					break;
				case <= 0.1f:
					Debug.Log("Good!");
					break;
				case <= 0.25f:
					Debug.Log("Ok");
					break;
				default:
					Debug.Log("kk");
					break;
			}

            HitNotes.Add(i);
            for (int n = 0; n < Notes.Count; n++)
            {
                if (Notes[n] != null && Notes[n].GetComponent<Note>().NoteIndex == i)
                {
                    Destroy(Notes[n]);
                }
            }
            string msg = currentTime - HitTimings.notes[i].timing < 0 ? "fast" : "late";
            onNoteHit.Invoke((int)Mathf.Floor((currentTime - HitTimings.notes[i].timing) * 1000));
        }
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
            if (currentTime >= 0 && !song.isPlaying)
            {
                song.Play();
            }
            for (int i = noteIndex; i < HitTimings.notes.Count; i++)
            {
                if (HitTimings.notes[i].timing -NoteFallTime <= currentTime)
                {
                    GameObject new_note;
                    if (HitTimings.notes[i].noteType == NoteType.FX1 || HitTimings.notes[i].noteType == NoteType.FX2)
                    {
                        new_note = Instantiate(fxnote, SpawnTransform);
                    }
                    {
                        new_note = Instantiate(note, SpawnTransform);
                    }
                    new_note.GetComponent<Note>().NoteIndex = i;
                    new_note.GetComponent<Note>().noteType = HitTimings.notes[i].noteType;
                    new_note.GetComponent<Note>().FallTime = NoteFallTime;
                    Notes.Add(new_note);
                    noteIndex = i + 1;
                }
            }

            List<NoteType> pressedKeys = GetLanePressed();
            if (pressedKeys.Count != 0)
            {
                for (int k = 0; k < pressedKeys.Count; k++)
                {
                    CalculateNoteHit(pressedKeys[k]);
                }
            }
        }
    }
}
