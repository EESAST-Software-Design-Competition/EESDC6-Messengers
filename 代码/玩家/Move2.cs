using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    private CharacterController player;
    public float speed = 5;
    public float steer = 20;
    public GameObject LeftTrack;
    public GameObject RightTrack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 s = transform.forward * speed * Time.deltaTime;
            transform.transform.position += s;
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -1 * steer * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, steer * Time.deltaTime, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 s = -0.5f * transform.forward * speed * Time.deltaTime;
            transform.transform.position += s;
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, steer * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, -1 * steer * Time.deltaTime, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * steer * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, steer * Time.deltaTime, 0);
        }
        LeftTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(-0.25f * vertical * Time.deltaTime, 0);
        RightTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(-0.25f * vertical * Time.deltaTime, 0);
        LeftTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(-0.25f * horizontal * Time.deltaTime, 0);
        RightTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(0.25f * horizontal * Time.deltaTime, 0);
    }
}
