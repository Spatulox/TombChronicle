using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggeredThings : MonoBehaviour
{
    public UnityEvent activated;
    public UnityEvent deactivated;
    public bool desactivateThing = false;
    public bool exitDetection = false;
    public string tagToActivate = "Player";
    private bool activatedState = true;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToActivate))
        {
            //activatedState = !activatedState;
            if (activatedState)
            {
                activated.Invoke();
                activatedState = !activatedState;
            }
            else if(desactivateThing)
            {
                deactivated.Invoke();
                activatedState = !activatedState;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToActivate) && exitDetection)
        {
                deactivated.Invoke();
        }
    }

}
