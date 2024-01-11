using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractionScript : MonoBehaviour
{
    private bool _thingInHand = false;
    private GameObject _player;
    private GameObject _robot;
    private GameObject _thingToThrow = null;

    private bool _toggleRobot;
    private void Start()
    {
        try
        {
            _player = GameObject.Find("Player").gameObject;
        }
        catch
        {
            Debug.Log("No player ??");
        }

        try
        {
            _robot = GameObject.Find("Robot").gameObject;
        }
        catch
        {
            Debug.Log("Pas de Robot");
        }

        if (_player != null)
        {
            _player = _player.transform.Find("FPS").gameObject;
        }
        
        if (_robot != null)
        {
            _robot = _robot.transform.Find("FPS").gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main != null)
            {
                var cameraTransform = Camera.main.transform;
                var direction = cameraTransform.rotation * Vector3.forward;
                
                if (Physics.Raycast(cameraTransform.position, direction,
                        out var hitInfo, 2f))
                {
                    var exitSign = hitInfo.transform.GetComponent<ExitSign>();
                    var reloadSign = hitInfo.transform.GetComponent<ReloadScene>();
                    var lever = hitInfo.transform.GetComponent<LeverScript>();
                    var thingObject = hitInfo.transform.gameObject;
                    
                    if (lever != null)
                    {
                        lever.ToggleLever();
                    }

                    if (exitSign != null)
                    {
                        exitSign.ExitLevel();
                    }
                    
                    if (reloadSign != null)
                    {
                        reloadSign.ReloadSceneX();
                    }

                    if (thingObject.transform.CompareTag("Thing") || thingObject.transform.CompareTag("UniqueTaking"))
                    {
                        Debug.Log("Yey");
                        Debug.Log(_thingInHand);
                        
                        if (!_thingInHand)
                        {
                            _thingInHand = !_thingInHand;
                            if (_player != null && !_toggleRobot)
                            {
                                thingObject.transform.parent = _player.transform;
                                thingObject.transform.localPosition = new Vector3(0.7f, -0.6f, 1.3f);
                                thingObject.transform.localRotation = Quaternion.Euler(Vector3.zero);

                                try
                                {
                                    thingObject.GetComponent<Rigidbody>().isKinematic = true;
                                }
                                catch
                                {
                                    
                                }
                                _thingToThrow = thingObject;
                            }
                            
                            if (_robot != null && _toggleRobot)
                            {
                                thingObject.transform.parent = _robot.transform;
                                thingObject.transform.localPosition = new Vector3(0f, -0.5f, -8f);
                                thingObject.transform.localRotation = Quaternion.Euler(Vector3.zero);

                                try
                                {
                                    thingObject.GetComponent<Rigidbody>().isKinematic = true;
                                }
                                catch
                                {
                                    
                                }
                                _thingToThrow = thingObject;
                            }
                        
                        }
                        else
                        {
                            Debug.Log("Yoy");
                            _thingToThrow.transform.parent = null;
                            _thingToThrow.GetComponent<Rigidbody>().isKinematic = false;
                            _thingInHand = !_thingInHand;
                        }
                    }
                }
                else
                {
                    if(_thingToThrow != null)
                    {
                        _thingToThrow.transform.parent = null;
                        _thingToThrow.GetComponent<Rigidbody>().isKinematic = false;
                        _thingInHand = !_thingInHand;
                    }
                    
                }
            }
        }
    }

    public void ToggleRobot()
    {
        _toggleRobot = !_toggleRobot;
    }
}
