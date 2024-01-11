using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizePrefab : MonoBehaviour
{
    private Vector3 initialScale;
    public bool autoSize;
    
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (autoSize)
        {
            AutoResize();
        }
    }

    public void AutoResize()
    {
        transform.localScale = initialScale;
    }
}
