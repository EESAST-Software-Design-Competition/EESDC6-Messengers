using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;

public class EnemyTankAim2 : MonoBehaviour
{
    public Transform target;

    public Transform turret;
    public float anglespeed = 0.003f;
    public float detectDistance = 100f;

    public float reactionForce = 10f;

    [Range(0.0f, 90.0f)]
    public float elevation = 25f;
    [Range(0.0f, 90.0f)]
    public float depression = 10f;
    [HideInInspector]
    public bool CanSeePlayer;
    public bool LightIsOn;

    private Vector3 TargetRotation;


    // Start is called before the first frame update
    void Start()
    {
        LightIsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //×Ô¶¯Ë÷µÐ
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (LightIsOn)
            {
                LightIsOn = false;
            }
            else
            {
                LightIsOn = true;
            }
        }
        if ((100f > Vector3.Distance(target.transform.position, transform.position))&&LightIsOn)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z)), anglespeed);
        }
    }
}
