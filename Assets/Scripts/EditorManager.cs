using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public float bpm = 160;
    public ChartData chartData = new();

    public GameObject note;
    public RectTransform PannelTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newNote = Instantiate(note, PannelTransform);
        }
    }

    
}
