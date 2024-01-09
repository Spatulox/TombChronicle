using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialScale;

    void Start()
    {
        initialPosition = transform.position;
        initialScale = transform.localScale;
    }

    public void ResetXPosition()
    {
        transform.position = initialPosition;
        if (transform.localScale != initialScale)
        {
            transform.localScale = initialScale;
        }
    }
}

