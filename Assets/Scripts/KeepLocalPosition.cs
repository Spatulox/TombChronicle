using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLocalPosition : MonoBehaviour
{
    public GameObject reference;
    public GameObject thingToKeep;
    public float _secondeBeforeStop;
    
    private Vector3 _initialLocalPosition;
    private bool _keepPosition = false;
    
    void Update()
    {
        if (_keepPosition)
        {
            Vector3 newRelativePosition = reference.transform.InverseTransformPoint(thingToKeep.transform.position);
            Vector3 positionOffset = newRelativePosition - _initialLocalPosition;
            thingToKeep.transform.localPosition -= positionOffset;
        }
        else
        {
            _initialLocalPosition = reference.transform.InverseTransformPoint(thingToKeep.transform.position);
        }
    }

    public void KeepPosition()
    {
        _keepPosition = true;
        Invoke("StopKeepingPosition", _secondeBeforeStop);
    }

    public void StopKeepingPosition()
    {
        _keepPosition = false;
    }
}
