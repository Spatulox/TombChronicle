using System;
using System.Collections;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    
    public float timeToTRavel = 0.5f;
    private float _height;
    public int secondBeforeClose = 10;
    private Vector3 _initialPos;
    private Vector3 _finalUpPos;
    private Vector3 _currPos;
    
    private bool _isTakingOff = false;
    private bool _isLanding = false;
    void Start()
    {
        _height = gameObject.GetComponent<Renderer>().bounds.size.y;
        this._initialPos = gameObject.transform.position;
        this._currPos = this._initialPos;
        this._finalUpPos = _initialPos + Vector3.up * _height;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = this._currPos;
    }

    public void UpperHeight()
    {
        if (!_isTakingOff && !_isLanding)
        {
            _isTakingOff = true;
            StartCoroutine(TakeOffObject());
        }
    }
    
    public void LowerHeight()
    {
        if (!_isTakingOff && !_isLanding)
        {
            _isLanding = true;
            StartCoroutine(LandObject());
        }
    }
    
    
    
    IEnumerator TakeOffObject()
    {
        if (Vector3.Distance(transform.position, _finalUpPos) < 0.1f)
        {
            _isTakingOff = false;
            yield break;
        }
        float time = 0f;

        while (time < timeToTRavel)
        {
            gameObject.transform.position = Vector3.Lerp(this._initialPos, this._finalUpPos, time / timeToTRavel);
            time += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.position = this._finalUpPos;
        this._currPos = gameObject.transform.position;
        
        _isTakingOff = false;
    }
    
    
    IEnumerator LandObject()
    {
        
        if (Vector3.Distance(transform.position, _initialPos) < 0.1f)
        {
            _isLanding = false;
            yield break;
        }
        yield return WaitAndDoSomething();
        float time = 0f;
        
        while (time < timeToTRavel)
        {
            gameObject.transform.position = Vector3.Lerp(this._finalUpPos, this._initialPos, time / timeToTRavel);
            time += Time.deltaTime;
            yield return null;
        }

        
        gameObject.transform.position = this._initialPos;
        this._currPos = gameObject.transform.position;
        _isLanding = false;
    }
    
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(secondBeforeClose);
    }
    
}
