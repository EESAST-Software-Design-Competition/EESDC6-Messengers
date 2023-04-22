using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap2 : MonoBehaviour
{ 
    private Camera minimapCamera;
    public GameObject player;
    private Vector3 offsetPosition;
    void Start()
    {
        minimapCamera = GameObject.Find("miniCamera2").GetComponent<Camera>();
        offsetPosition = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        minimapCamera.transform.position = offsetPosition + player.transform.position;
    }//�����������ƶ�//
    public void ZoomInButtonClick2()
    {
        if(minimapCamera.fieldOfView <= 100)
        minimapCamera.fieldOfView += 5;
    }//��СС��ͼ//
    public void ZoomOutButtonClick2()
    {
        if(minimapCamera.fieldOfView >= 7)
        minimapCamera.fieldOfView -= 5;
    }//�Ŵ�С��ͼ//     
}

