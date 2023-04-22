using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankAimming : MonoBehaviour
{
    // 旋转速度
    public float steer = 20;

    private void Start()
    {

    }

    void Update()
    { 

        float horizontal = Input.GetAxis("spin");
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(0, -1 * steer * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(0, steer * Time.deltaTime, 0);
        }

    }
}