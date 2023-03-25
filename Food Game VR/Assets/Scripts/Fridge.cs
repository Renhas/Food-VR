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

    private bool isAnim = false;
    public void Open() 
    {
        if(!isAnim) StartCoroutine(Anim());
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
