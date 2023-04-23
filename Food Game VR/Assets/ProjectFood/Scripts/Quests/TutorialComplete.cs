using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialComplete : MonoBehaviour
{
    [SerializeField]
    private GameObject completeWindow;
    private QuestQueue controller;
    void Start()
    {
        controller = GetComponent<QuestQueue>();
    }

    
    void Update()
    {
        if (controller.tutorialComplete)
            TutorialEnd();
    }

    private void TutorialEnd() 
    {
        completeWindow.SetActive(true);
    }
}
