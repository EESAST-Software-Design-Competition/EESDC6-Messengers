using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera2 : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    public float mouseScrollSensitivity = 5f;
    public Transform target;
    public float distanceFromTarget = 8f;
    public Vector2 pitchMinMax = new Vector2(-40f, 85f);
    public float rotationSmoothTime = 0.12f;
    private float yaw;
    private float pitch;

    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
    [HideInInspector]
    public float actualMouseSensitivity = 1f;
    [HideInInspector]
    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        distance = 8;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * actualMouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * actualMouseSensitivity;
        distance -= Input.GetAxis("Mouse ScrollWheel") * mouseScrollSensitivity;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        distance = Mathf.Clamp(distance, 3f, 16f);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw, 0f), ref rotationSmoothVelocity, rotationSmoothTime);
    }

    void LateUpdate()
    {
        Vector3 targetRotation = currentRotation;
        transform.eulerAngles = targetRotation;
        distanceFromTarget = distance;
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}

