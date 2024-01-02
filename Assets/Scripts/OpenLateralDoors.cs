using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLateralDoors : MonoBehaviour
{
    public float timeToTRavel = 0.5f;
    public int secondBeforeClose = 10;
    
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
        
        
        _rWidth = rightPart.GetComponent<Renderer>().bounds.size.x;
        _lWidth = leftPart.GetComponent<Renderer>().bounds.size.x;
        
        _initialRightPos = rightPart.transform.position;
        _initialLeftPos = leftPart.transform.position;
        
        _currPosRightPart = _initialRightPos;
        _currPosLeftPart = _initialLeftPos;
        
        _finalRightPos = _initialRightPos + Vector3.left * _rWidth;
        _finalLeftPos = _initialLeftPos + Vector3.right * _lWidth;
    }

    private void FixedUpdate()
    {
        rightPart.transform.position = _currPosRightPart;
        leftPart.transform.position = _currPosLeftPart;
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
        if (Vector3.Distance(rightPart.transform.position, _finalRightPos) < 0.1f || Vector3.Distance(leftPart.transform.position, _finalLeftPos) < 0.1f)
        {
            _isOpening = false;
            yield break;
        }
        float time = 0f;

        while (time < timeToTRavel)
        {
            rightPart.transform.position = Vector3.Lerp(_initialRightPos, _finalRightPos, time / timeToTRavel);
            leftPart.transform.position = Vector3.Lerp(_initialLeftPos, _finalLeftPos, time / timeToTRavel);
            time += Time.deltaTime;
            yield return null;
        }

        rightPart.transform.position = _finalRightPos;
        leftPart.transform.position = _finalLeftPos;
        _currPosRightPart = rightPart.transform.position;
        _currPosLeftPart = leftPart.transform.position;
        
        _isOpening = false;
    }
    
    
    IEnumerator CloseObject()
    {
        
        if (Vector3.Distance(rightPart.transform.position, _initialRightPos) < 0.1f || Vector3.Distance(leftPart.transform.position, _initialLeftPos) < 0.1f)
        {
            _isClosing = false;
            yield break;
        }
        yield return WaitAndDoSomething();
        float time = 0f;
        
        while (time < timeToTRavel)
        {
            rightPart.transform.position = Vector3.Lerp(_finalRightPos, _initialRightPos, time / timeToTRavel);
            leftPart.transform.position = Vector3.Lerp(_finalLeftPos, _initialLeftPos, time / timeToTRavel);
            time += Time.deltaTime;
            yield return null;
        }

        
        rightPart.transform.position = _initialRightPos;
        leftPart.transform.position = _initialLeftPos;
        _currPosRightPart = rightPart.transform.position;
        _currPosLeftPart = leftPart.transform.position;
        _isClosing = false;
    }
    
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(secondBeforeClose);
    }
}
