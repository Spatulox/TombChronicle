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
    public bool desactivate = true;
    public string tagToActivate = "Player";
    private bool activatedState;

    private bool saveStateDesactivate;

    private void Start()
    {
        saveStateDesactivate = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToActivate) && saveStateDesactivate)
        {
            saveStateDesactivate = desactivate;
            ToggleButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToActivate) && exitDetection && desactivate)
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