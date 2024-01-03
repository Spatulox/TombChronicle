using System;
using Unity.VisualScripting;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public Transform bodyTransform; //position du jouer
    public Transform cameraTransform;
    public Rigidbody robotRigidBody;
    public float speed;
    private float saveSpeed;
    private float sprint;
    public float yawRotationSpeed;
    public float pitchRotationSpeed;
    public float jump;
    
    private bool remoteControl = false;

    private Vector3 directionIntent;
    private bool wantToJump;
    
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        sprint = speed * 2;
        saveSpeed = speed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        if (remoteControl)
        {

            if (Input.GetKey(KeyCode.W))
            {
                directionIntent += Vector3.forward;
            }

            if (Input.GetKey(KeyCode.S))
            {
                directionIntent += Vector3.back;
            }

            if (Input.GetKey(KeyCode.A))
            {
                directionIntent += Vector3.left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                directionIntent += Vector3.right;
            }

            var mouseXDelta = Input.GetAxis("Mouse X");

            bodyTransform.Rotate(Vector3.up, Time.deltaTime * yawRotationSpeed * mouseXDelta);

            var mouseYDelta = Input.GetAxis("Mouse Y");

            var rotation = cameraTransform.localRotation;

            var rotationX = rotation.eulerAngles.x;

            rotationX += -Time.deltaTime * pitchRotationSpeed * mouseYDelta;


            var unClampedRotationX = rotationX;

            if (unClampedRotationX >= 180)
            {
                unClampedRotationX -= 360;
            }

            var clampedRotationX = Mathf.Clamp(unClampedRotationX, -60, 60);

            cameraTransform.localRotation =
                Quaternion.Euler(new Vector3(
                    clampedRotationX,
                    rotation.eulerAngles.y,
                    rotation.eulerAngles.z
                ));

            if (Input.GetKeyDown(KeyCode.Space) &&
                Physics.SphereCast(bodyTransform.position + Vector3.up * (0.1f + 0.45f), 0.45f, Vector3.down,
                    out var _hitInfo,
                    0.11f)
               )
            {
                wantToJump = true;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprint;
            }
            else
            {
                speed = saveSpeed;
            }
        }
    }
    
    private void FixedUpdate()
    {
        if (remoteControl)
        {
            var normalizeDirection = directionIntent.normalized;
            bodyTransform.position += bodyTransform.rotation * normalizeDirection * (Time.deltaTime * speed);
            directionIntent = Vector3.zero;

            // Fait la gravité
            //playerRigidbody.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);

            if (wantToJump)
            {
                robotRigidBody.velocity += Vector3.up * jump;
                wantToJump = false;

                //playerRigidbody.AddForce(* Vector3.up * jump, ForceMode.VelocityChange)

                /*
                 * playerRigidbody.AddForce(
                 * Vector3.up * jump, ForceMode.VelocityChange) //=> pour un changement de gravité
                 *
                 * 
                 */
            }
        }
    }

    public void toggleRemote()
    {
        remoteControl = !remoteControl;
    }
}


/*
*/