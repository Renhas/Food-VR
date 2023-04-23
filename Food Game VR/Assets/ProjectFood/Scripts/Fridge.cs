using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField]
    private float yRotation = 50f;
    [SerializeField]
    private float animationDuration = 2f;
    [SerializeField]
    private bool isOpen = false;
    private AudioSource sound;
    private bool isAnim = false;
    private void Start() 
    {
        sound = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
    }
    public void Open() 
    {
        if (!isAnim) { 
            StartCoroutine(Anim());
            sound.Play();
        }
    }

    private IEnumerator Anim() 
    {
        isAnim = true;
        float progress = 0;

        while (progress < animationDuration) 
        {
            float new_y = YCalc(progress);
            var rotation = transform.localRotation.eulerAngles;
            rotation.y = new_y;
            transform.localRotation = Quaternion.Euler(rotation);
            progress += Time.deltaTime;
            yield return null;
        }

        isOpen = !isOpen;
        isAnim = false;
    }

    private float YCalc(float x) 
    {
        if (isOpen)
        {
            return -yRotation / animationDuration * x + yRotation;
        }
        else 
        {
            return yRotation / animationDuration * x;
        }
    }
}
