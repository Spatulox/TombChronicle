using UnityEngine;
using System.Collections;

public class RotatePrefab : MonoBehaviour
{
	public GameObject prefab;

	public string axeToRotate;

	public float degreeToRotate;
	
	public float timeToRotate;
	
	private bool _isTurning = false;
	private float _time;
	private Quaternion _endRotation;

	public void RotateXPrefab()
    {
	    if (!_isTurning)
	    {
		    _isTurning = true;
		    StartCoroutine(RotateAfterDelay());
		    StartCoroutine(RotateCoroutine());
		    StartCoroutine(RotateAfterDelay());
	    }
	    
    }
    
    private IEnumerator RotateCoroutine()
    {
	    
	    Quaternion startRotation = prefab.transform.rotation;
	    if (axeToRotate == "x")
	    {
		    _endRotation = Quaternion.Euler(degreeToRotate, 0, 0) * startRotation;
	    }
	    else if (axeToRotate == "y")
	    {
		    _endRotation = Quaternion.Euler(0, degreeToRotate, 0) * startRotation;
	    }
	    else if (axeToRotate == "z")
	    {
		    _endRotation = Quaternion.Euler(0, 0, degreeToRotate) * startRotation;
	    }
	    
	    
	    float t = 0f;

	    while (t < 1) {
		    t += Time.deltaTime / timeToRotate;
		    prefab.transform.rotation = Quaternion.Slerp(startRotation, _endRotation, t);
		    yield return null;
	    }
	    
	    prefab.transform.rotation = _endRotation;

    }
    
    private IEnumerator RotateAfterDelay()
    {
	    yield return new WaitForSeconds(timeToRotate+0.5f);
	    _isTurning = false;
    }
}
