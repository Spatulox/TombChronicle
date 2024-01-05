using UnityEngine;
using System.Collections;

public class RotatePrefab : MonoBehaviour
{
	public GameObject prefab;

	public string axeToRotate;

	public float degreeToRotate;
	
	public float timeToRotate;
	
	private float _time;
	private Quaternion _endRotation;

    // Update is called once per frame
    
    public void RotateXPrefab()
    {
	    StartCoroutine(RotateCoroutine());
    }
    
    private IEnumerator RotateCoroutine()
    //void Update()
    {
	    
	    Quaternion startRotation = prefab.transform.rotation;
	    //Quaternion endRotation = Quaternion.identity;
	    
	    if (axeToRotate == "x")
	    {
		    _endRotation = Quaternion.Euler(degreeToRotate, 0, 0) * startRotation;
		    //prefab.transform.Rotate(new Vector3(degreeToRotate,0,0), Space.Self);    
	    }
	    else if (axeToRotate == "y")
	    {
		    _endRotation = Quaternion.Euler(0, degreeToRotate, 0) * startRotation;
		    //prefab.transform.Rotate(new Vector3(0,degreeToRotate,0), Space.Self);
	    }
	    else if (axeToRotate == "z")
	    {
		    _endRotation = Quaternion.Euler(0, 0, degreeToRotate) * startRotation;
		    //prefab.transform.Rotate(new Vector3(0,0,degreeToRotate), Space.Self);
	    }
	    
	    
	    float t = 0f;
	    //Quaternion startRotation = prefab.transform.rotation;

	    while (t < 1) {
		    t += Time.deltaTime / timeToRotate;
		    prefab.transform.rotation = Quaternion.Slerp(startRotation, _endRotation, t);
		    yield return null;
	    }
	    
	    prefab.transform.rotation = _endRotation; 

    }
}
