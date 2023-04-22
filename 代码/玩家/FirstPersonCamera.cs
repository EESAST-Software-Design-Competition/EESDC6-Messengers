using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public CanvasGroup screenMask;
    public bool aimed;

    private void Start()
    {

    }

    void Update()
    {
        if (aimed == true)
        { screenMask.alpha = 1; }
        else { screenMask.alpha = 0; }
    }
}
