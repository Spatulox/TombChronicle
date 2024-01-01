using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
	public GameObject prefab;

	public string axeToRotate;

	public float degreeToRotate;
	
	public float timeToRotate;
	
	private float _time;
	private Quaternion _targetRotation;
	
	// Start is called before the first frame update
    void Start()
    {
	    
    }

    // Update is called once per frame
    void Update()
    {
	    if (axeToRotate == "x")
	    {
		    _targetRotation = Quaternion.Euler(degreeToRotate, 0, 0);
		    //prefab.transform.Rotate(new Vector3(degreeToRotate,0,0), Space.Self);    
	    }
	    else if (axeToRotate == "y")
	    {
		    _targetRotation = Quaternion.Euler(0, degreeToRotate, 0);
		    //prefab.transform.Rotate(new Vector3(0,degreeToRotate,0), Space.Self);
	    }
	    else if (axeToRotate == "z")
	    {
		    _targetRotation = Quaternion.Euler(0, 0, degreeToRotate);
		    //prefab.transform.Rotate(new Vector3(0,0,degreeToRotate), Space.Self);
	    }
	    
	    
	    _time += Time.deltaTime;
	    if (_time < timeToRotate)
	    {
		    float t = _time / timeToRotate;
		    transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, t);
	    }

    }
}
