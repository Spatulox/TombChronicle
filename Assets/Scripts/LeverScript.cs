using System;
using UnityEngine;
using UnityEngine.Events;

public class LeverScript : MonoBehaviour
{
    public UnityEvent activated;
    public UnityEvent deactivated;
    
    private bool activatedState;
    private GameObject baseLever;

    public void ToggleLever()
    {
        baseLever = transform.Find("BaseLeverRotate").gameObject;
        
        Debug.Log(baseLever);
        
        activatedState = !activatedState;
        if (activatedState)
        {
            Debug.Log("Oucouc");
            baseLever.transform.Rotate(110f, 0f, 0f, Space.Self);
            //activated.Invoke();
        }
        else
        {
            Debug.Log("sdryhv");
            baseLever.transform.Rotate(-110f, 0f, 0f, Space.Self);
            //deactivated.Invoke();
        }
        
    }
}