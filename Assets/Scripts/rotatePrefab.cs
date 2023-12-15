using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
	public GameObject prefab;

	public string axeToRotate;

	public float degreeToRotate;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (axeToRotate == "x")
	    {
		    prefab.transform.Rotate(new Vector3(degreeToRotate,0,0), Space.Self);    
	    }
	    else if (axeToRotate == "y")
	    {
		    prefab.transform.Rotate(new Vector3(0,degreeToRotate,0), Space.Self);
	    }
	    else if (axeToRotate == "z")
	    {
		    prefab.transform.Rotate(new Vector3(0,0,degreeToRotate), Space.Self);
	    }

    }
}
