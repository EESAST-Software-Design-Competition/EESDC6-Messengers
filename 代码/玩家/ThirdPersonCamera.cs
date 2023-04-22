using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // ���������
    public float mouseSensitivity = 0.01f;
    // ����������
    public float mouseScrollSensitivity = 5f;
    // �����˳�Ŀ��
    public Transform target;
    // �������Ŀ���λ��
    public float distanceFromTarget = 8f;
    // y���������
    public Vector2 pitchMinMax = new Vector2(-40f, 85f);
    // ��ת�˶�ƽ��ʱ��
    public float rotationSmoothTime = 0.12f;
    // x����
    private float yaw;
    // y����
    private float pitch;

    // ��ת�˶�ƽ���ٶ�
    Vector3 rotationSmoothVelocity;
    // ��ǰ����ת
    Vector3 currentRotation;
    // ʵ�����������
    [HideInInspector]
    public float actualMouseSensitivity = 0.1f;
    // ����������Զ�����
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
        yaw += Input.GetAxis("Mouse X") * actualMouseSensitivity * 0.2f;
        pitch -= Input.GetAxis("Mouse Y") * actualMouseSensitivity*0.2f;
        distance -= Input.GetAxis("Mouse ScrollWheel") * mouseScrollSensitivity;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        distance = Mathf.Clamp(distance, 3f, 16f);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw, 0f), ref rotationSmoothVelocity, rotationSmoothTime);
    }

    // ʹ��LateUpdate��target.position���ú��Ժ������������λ��
    void LateUpdate()
    {
        Vector3 targetRotation = currentRotation;
        transform.eulerAngles = targetRotation;
        distanceFromTarget = distance;
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}

