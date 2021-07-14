using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesVisualizer : MonoBehaviour
{
    private Floor floor;
    public Text visualizer;

    // Start is called before the first frame update
    void Start()
    {
        floor = GetComponent<Floor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecalculateVisualizer(int lives)
    {
        //change Ui, background or whatever display it is, by the current lives
        DebugVisualizer(lives);
    }

    private void DebugVisualizer(int lives)
    {
        visualizer.text = Mathf.Max(0,lives).ToString();
    }
}
