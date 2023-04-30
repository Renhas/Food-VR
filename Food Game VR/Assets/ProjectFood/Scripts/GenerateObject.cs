using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToGenerate;
    [SerializeField] private float spawnTime = 1f;

    void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate() 
    {
        while (true)
        {
            if (transform.childCount > 0) 
            {
                yield return new WaitForSeconds(1);
                continue;
            }

            yield return new WaitForSeconds(spawnTime);

            GameObject generatedObject = Instantiate(objectToGenerate);

            generatedObject.transform.parent = transform;
            generatedObject.transform.localPosition = Vector3.zero;
        }
    }
}
