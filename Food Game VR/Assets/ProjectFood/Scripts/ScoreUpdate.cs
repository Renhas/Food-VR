using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    private GameManager manager;
    private Text text;
    private int localScore;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponent<Text>();
        UpdateText();
    }

    void Update()
    {
        if (localScore != manager.Score) 
        {
            UpdateText();
        }
    }

    private void UpdateText() 
    {
        localScore = manager.Score;
        text.text = $"Score: {localScore}";
    }
}
