using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent activated;
    public UnityEvent deactivated;
    public Material activatedMaterial;
    public Material deactivatedMaterial;
    public MeshRenderer meshRenderer;
    public bool exitDetection = true;
    public string tagToActivate = "Player";
    private bool activatedState;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToActivate))
        {
            ToggleButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToActivate) && exitDetection)
        {
            ToggleButton();
        }
    }

    public void ToggleButton()
    {
        activatedState = !activatedState;
        if (activatedState)
        {
            meshRenderer.material = activatedMaterial;
            activated.Invoke();
        }
        else
        {
            meshRenderer.material = deactivatedMaterial;
            deactivated.Invoke();
        }
    }
}