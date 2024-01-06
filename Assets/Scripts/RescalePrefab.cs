using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescalePrefab : MonoBehaviour
{
    public GameObject gameObject;
    public float newSize = 1f;
    public float duration = 2f;
    
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = gameObject.transform.localScale;
    }

    public void Upscale()
    {
        StartCoroutine(ScaleOverTime());
    }
    
    private IEnumerator ScaleOverTime()
    {
        Vector3 targetScale = new Vector3(newSize, newSize, newSize);
        float currentTime = 0.0f;

        while (currentTime < duration)  
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.localScale = targetScale;
    }
}
