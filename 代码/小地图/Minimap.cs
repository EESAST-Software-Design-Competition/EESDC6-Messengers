using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private Camera minimapCamera;
    public GameObject player;
    private Vector3 offsetPosition;
    // Start is called before the first frame update
    void Start()
    {
        minimapCamera = GameObject.Find("MinimapCamera").GetComponent<Camera>();
        offsetPosition = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        minimapCamera.transform.position = offsetPosition + player.transform.position;
    }//�����������ƶ�//
    public void ZoomInButtonClick()
    {
        if(minimapCamera.fieldOfView <= 100)
        minimapCamera.fieldOfView += 5;
    }//��СС��ͼ//
    public void ZoomOutButtonClick()
    {
        if(minimapCamera.fieldOfView >= 7)
        minimapCamera.fieldOfView -= 5;
    }//�Ŵ�С��ͼ//    
}
