using UnityEngine;

public class PlayerInteractionScript : MonoBehaviour
{
    private bool _thingInHand = false;
    private GameObject _player;
    private GameObject _thingToThrow;
    private void Start()
    {
        _player = GameObject.Find("Player").gameObject;
        if (_player != null)
        {
            _player = _player.transform.Find("FPS").gameObject;
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
                
                if (_thingInHand)
                {
                    _thingToThrow.transform.parent = null;
                    _thingToThrow.GetComponent<Rigidbody>().isKinematic = false;
                    _thingInHand = !_thingInHand;
                }

                if (Physics.Raycast(cameraTransform.position, direction,
                        out var hitInfo, 2f))
                {
                    var exitSign = hitInfo.transform.GetComponent<ExitSign>();
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

                    if (thingObject.transform.CompareTag("Thing"))
                    {
                        if (!_thingInHand)
                        {
                            _thingInHand = !_thingInHand;
                            if (_player != null)
                            {
                                thingObject.transform.parent = _player.transform;
                                thingObject.transform.localPosition = new Vector3(0.7f, -0.5f, 1.2f);
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
                    }
                }
            }
        }
    }
}
