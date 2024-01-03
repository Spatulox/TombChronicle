using UnityEngine;

public class PlayerInteractionScript : MonoBehaviour
{
    // Update is called once per frame
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
                    var lever = hitInfo.transform.GetComponent<LeverScript>();

                    if (lever != null)
                    {
                        lever.ToggleLever();
                    }
                }
            }
        }
    }
}
