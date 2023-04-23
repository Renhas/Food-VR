using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float grillTime = 30;
    [SerializeField] private float drinkTime = 10;
    [SerializeField] private float cookies = 20;
    [SerializeField] private float customerWaitTime = 180;
    [SerializeField] private int scoreFactor = 1;
    [SerializeField] private int score = 0;
    [SerializeField] private int goodScore = 20;
    [SerializeField] private int badScore = 10;
    
    public bool customerFrozen = false;

    public float GrillTime { get { return grillTime; } }
    public float DrinkTime { get { return drinkTime; } }
    public float Cookies { get { return cookies; } }
    public float CustomerWaitTime { get { return customerWaitTime; } }
    public float ScoreFactor { get { return scoreFactor; } }
    public int Score { get { return score; } }


    public void IncreaseGrillTime(float time, float coeff = 0.5f) 
    {

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            var temp = grillTime;
            grillTime *= coeff;
            yield return new WaitForSeconds(time);
            grillTime = temp;

        }
        
    }

    public void FreezeCustomer(float time) 
    {

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            customerFrozen = true;
            yield return new WaitForSeconds(time);
            customerFrozen = false;
        }

    }

    public void IncreaseDrinkTime(float time, float coeff = 0.5f) 
    {

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            var temp = drinkTime;
            drinkTime *= coeff;
            yield return new WaitForSeconds(time);
            drinkTime = temp;
        }
        

    }

    public void IncreaseScoreFactor(float time, int coeff = 5) 
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            var temp = scoreFactor;
            scoreFactor *= coeff;
            yield return new WaitForSeconds(time);
            scoreFactor = temp;
        }
        
    }

    public void AddScore() 
    {
        score += goodScore * scoreFactor;
    }

    public void RemoveScore() 
    {
        score -= badScore;
    }

    public void LoadNext() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPrev() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
