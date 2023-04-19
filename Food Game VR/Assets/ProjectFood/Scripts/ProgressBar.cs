using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private GameManager manager;
    private Image bar;
    private float fillTime;
    [SerializeField] private bool progressiv = true;

    private float progress;
    private Coroutine coroutine;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        fillTime = manager.CustomerWaitTime;
        bar = GetComponent<Image>();
        progress = progressiv ? 0f : fillTime;
        coroutine = StartCoroutine(Fill());
    }

    IEnumerator Fill() 
    {
        while (progressiv ? (progress <= fillTime) : (progress >= 0)) 
        {
            if (manager.customerFrozen) 
            {
                yield return null;
                continue;
            }
            bar.fillAmount = Mathf.Lerp(0, 1, progress/fillTime);
            progress = progressiv ? progress + Time.deltaTime : progress - Time.deltaTime;
            yield return null;
        }
    }

    public void GiveCookies() 
    {
        progress += manager.Cookies;
        progress = Mathf.Min(progress, fillTime);
    }

    public float GetProgress() 
    { 
        return progress / fillTime;
    }
}
