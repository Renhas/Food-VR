using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesControl : MonoBehaviour
{
    private GameObject nextButton;
    private GameObject prevButton;
    private int currentChild;
    void Start()
    {
        nextButton = transform.parent.GetChild(1).gameObject;
        prevButton = transform.parent.GetChild(2).gameObject;
        currentChild = 0;
        Reset();
    }

    public void Reset() 
    {
        transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 1; i < transform.childCount; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        currentChild = 0;
        ButtonsCheck();
    }

    public void Next() 
    {
        if (currentChild >= transform.childCount - 1) return;

        ChildActivate(currentChild + 1);
        ButtonsCheck();
        
    }

    public void Prev() 
    {
        if (currentChild == 0) return;

        ChildActivate(currentChild - 1);
        ButtonsCheck();
    }

    private void ButtonsCheck() 
    {
        if (currentChild == 0) prevButton.SetActive(false);
        else prevButton.SetActive(true);

        if(currentChild == transform.childCount - 1) nextButton.SetActive(false);
        else nextButton.SetActive(true);
    }

    public void ChildActivate(int id) 
    {
        transform.GetChild(currentChild).gameObject.SetActive(false);
        currentChild = id;
        transform.GetChild(currentChild).gameObject.SetActive(true);
    }

}
