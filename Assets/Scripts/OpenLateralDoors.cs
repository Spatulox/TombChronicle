using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLateralDoors : MonoBehaviour
{
    public float timeToTRavel = 0.5f;
    public int secondBeforeClose = 10;
    public int automaticClose = 1;
    
    private float _rWidth;
    private float _lWidth;
    
    private GameObject rightPart;
    private GameObject leftPart;
    
    private Vector3 _initialRightPos;
    private Vector3 _initialLeftPos;
    private Vector3 _finalRightPos;
    private Vector3 _finalLeftPos;
    private Vector3 _currPosRightPart;
    private Vector3 _currPosLeftPart;

    private bool _isOpening = false;
    private bool _isClosing = false;
    void Start()
    {
        rightPart = transform.Find("rightPart").gameObject;
        leftPart = transform.Find("leftPart").gameObject;
        
        /*
        _rWidth = 12.19082f;
        _lWidth = 12.12706f;
        */
        
        // Get local z size
        Vector3 localSize = rightPart.GetComponent<BoxCollider>().size;
        _rWidth = localSize.z * transform.lossyScale.z;
        
        localSize = leftPart.GetComponent<BoxCollider>().size;
        _lWidth = localSize.z * transform.lossyScale.z;

        // Fait des trucs
        _initialRightPos = rightPart.transform.localPosition;
        _initialLeftPos = leftPart.transform.localPosition;
        
        _currPosRightPart = _initialRightPos;
        _currPosLeftPart = _initialLeftPos;

        // Calculer les positions finales en utilisant les coordonnées locales par rapport au parent
        _finalRightPos = new Vector3(rightPart.transform.localPosition.x, rightPart.transform.localPosition.y, _rWidth*0.65f);
        _finalLeftPos = new Vector3(leftPart.transform.localPosition.x, leftPart.transform.localPosition.y, -_lWidth*0.65f);
        
    }

    private void FixedUpdate()
    {
        rightPart.transform.localPosition = _currPosRightPart;
        leftPart.transform.localPosition = _currPosLeftPart;
    }
    
    
    public void OpenDoors()
    {
        if (!_isOpening && !_isClosing)
        {
            _isOpening = true;
            StartCoroutine(OpenObject());
        }
    }
    
    public void CloseDoors()
    {
        if (!_isOpening && !_isClosing)
        {
            _isClosing = true;
            StartCoroutine(CloseObject());
        }
    }
    
    
    
    IEnumerator OpenObject()
    {
        if (Vector3.Distance(rightPart.transform.localPosition, _finalRightPos) < 0.1f || Vector3.Distance(leftPart.transform.localPosition, _finalLeftPos) < 0.1f)
        {
            _isOpening = false;
            yield break;
        }
        float time = 0f;

        while (time < timeToTRavel)
        {
            rightPart.transform.localPosition  = Vector3.Lerp(_initialRightPos, _finalRightPos, time / timeToTRavel);
            leftPart.transform.localPosition  = Vector3.Lerp(_initialLeftPos, _finalLeftPos, time / timeToTRavel);
            time += Time.deltaTime;
            yield return null;
        }

        rightPart.transform.localPosition = _finalRightPos;
        leftPart.transform.localPosition = _finalLeftPos;
        _currPosRightPart = rightPart.transform.localPosition;
        _currPosLeftPart = leftPart.transform.localPosition;

        _isOpening = false;
        
        if (automaticClose == 1)
        {
            yield return StartCoroutine(StopFor());
            CloseDoors();
        }
    }
    
    
    IEnumerator CloseObject()
    {
        
        if (Vector3.Distance(rightPart.transform.localPosition, _initialRightPos) < 0.1f || Vector3.Distance(leftPart.transform.localPosition, _initialLeftPos) < 0.1f)
        {
            _isClosing = false;
            yield break;
        }
        yield return WaitAndDoSomething();
        float time = 0f;
        
        while (time < timeToTRavel)
        {
            rightPart.transform.localPosition  = Vector3.Lerp(_finalRightPos, _initialRightPos, time / timeToTRavel);
            leftPart.transform.localPosition  = Vector3.Lerp(_finalLeftPos, _initialLeftPos, time / timeToTRavel);
            time += Time.deltaTime;
            yield return null;
        }

        
        rightPart.transform.localPosition = _initialRightPos;
        leftPart.transform.localPosition = _initialLeftPos;
        _currPosRightPart = rightPart.transform.localPosition;
        _currPosLeftPart = leftPart.transform.localPosition;
        _isClosing = false;
    }
    
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(secondBeforeClose);
    }
    
    IEnumerator StopFor()
    {
        
        yield return new WaitForSeconds(secondBeforeClose);
    }
}
