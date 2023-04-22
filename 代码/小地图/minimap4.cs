using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap4 : MonoBehaviour
{
    private Camera minimapCamera;
    public GameObject player;
    private Vector3 offsetPosition;
    void Start()
    {
        minimapCamera = GameObject.Find("miniCamera4").GetComponent<Camera>();
        offsetPosition = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        minimapCamera.transform.position = offsetPosition + player.transform.position;
    }//�����������ƶ�//
    public void ZoomInButtonClick4()
    {
        if( minimapCamera.fieldOfView <= 150)
        minimapCamera.fieldOfView += 5;
    }//��СС��ͼ//
    public void ZoomOutButtonClick4()
    {
        if( minimapCamera.fieldOfView >= 7)
        minimapCamera.fieldOfView -= 5;
    }//�Ŵ�С��ͼ//     
}
