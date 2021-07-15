using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesVisualizer : MonoBehaviour
{
    private Floor floor;
    public Text visualizer;
    List<GameObject> castlesUp = new List<GameObject>();
    List<GameObject> castlesDown = new List<GameObject>();
    [SerializeField] private List<int> castleDestructionOrder = new List<int>();


    void Awake()
    {
        floor = GetComponent<Floor>();
        FillCastlesLists();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecalculateVisualizer(int lives)
    {
        //change Ui, background or whatever display it is, by the current lives
        //DebugVisualizer(lives);
        CastlesDisplay(lives);
    }

    private void CastlesDisplay(int lives)
    {
        if (lives > castlesUp.Count)
        {
            Debug.LogWarning("Error, there are more lives than castles.");
            return;
        }

        for (int i = 0; i < castleDestructionOrder.Count; i++)
        {
            int castleIndex = castleDestructionOrder[i]-1;
            bool condition = i <= lives-1;
            castlesUp[castleIndex].SetActive(condition);
            castlesDown[castleIndex].SetActive(!condition);
        }
    }

    private void DebugVisualizer(int lives)
    {
        visualizer.text = Mathf.Max(0,lives).ToString();
    }

    private void FillCastlesLists()
    {
        for(int i = 0; i < transform.GetChild(0).GetChild(1).childCount; ++i)
        {
            castlesUp.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
        }

        for (int i = 0; i < transform.GetChild(0).GetChild(2).childCount; ++i)
        {
            castlesDown.Add(transform.GetChild(0).GetChild(2).GetChild(i).gameObject);
        }
    }
}
