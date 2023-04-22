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
        // 左shift键可以切换摄像机
        if (Input.GetMouseButtonDown(1))
        {
            isThirdPerson = !isThirdPerson;
        }
        if (isThirdPerson) //当前使用第三人称摄像机
        {
            // 设置第一人称摄像机
            FirstPersonCamera.GetComponent<Camera>().enabled = false;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = false;
            FirstPersonCamera.GetComponent<FirstPersonCamera>().aimed = false;

            // 设置第三人称摄像机
            TPCamera.GetComponent<Camera>().enabled = true;
            TPCamera.GetComponent<AudioListener>().enabled = true;
        }
        else //当前使用第一人称摄像机
        {
            // 设置第一人称摄像机
            FirstPersonCamera.GetComponent<Camera>().enabled = true;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = true;
            FirstPersonCamera.GetComponent<FirstPersonCamera>().aimed = true;

            // 设置第三人称摄像机
            TPCamera.GetComponent<Camera>().enabled = false;
            TPCamera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
