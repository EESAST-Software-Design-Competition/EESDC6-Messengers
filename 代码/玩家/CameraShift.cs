using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class CameraShift : MonoBehaviour
{
    public Transform TPCamera;
    public Transform FirstPersonCamera;

    private bool isThirdPerson = true;

    private void Start()
    {
    }

    void Update()
    {
        // ��shift�������л������
        if (Input.GetMouseButtonDown(1))
        {
            isThirdPerson = !isThirdPerson;
        }
        if (isThirdPerson) //��ǰʹ�õ����˳������
        {
            // ���õ�һ�˳������
            FirstPersonCamera.GetComponent<Camera>().enabled = false;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = false;
            FirstPersonCamera.GetComponent<FirstPersonCamera>().aimed = false;

            // ���õ����˳������
            TPCamera.GetComponent<Camera>().enabled = true;
            TPCamera.GetComponent<AudioListener>().enabled = true;
        }
        else //��ǰʹ�õ�һ�˳������
        {
            // ���õ�һ�˳������
            FirstPersonCamera.GetComponent<Camera>().enabled = true;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = true;
            FirstPersonCamera.GetComponent<FirstPersonCamera>().aimed = true;

            // ���õ����˳������
            TPCamera.GetComponent<Camera>().enabled = false;
            TPCamera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
