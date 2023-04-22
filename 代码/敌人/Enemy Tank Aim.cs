using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Runtime.CompilerServices;

public class EnemyTankAim : MonoBehaviour
{
    public Transform target;

    public Transform turret;
    public float anglespeed = 0.001f;
    public float detectDistance = 50f;

    public float reactionForce = 10f;

    [Range(0.0f, 90.0f)]
    public float elevation = 25f;
    [Range(0.0f, 90.0f)]
    public float depression = 10f;
    [HideInInspector]
    public bool CanSeePlayer;
    

    private Vector3 TargetRotation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //×Ô¶¯Ë÷µÐ
        if (50f > Vector3.Distance(target.transform.position, transform.position))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z)), anglespeed);
        }
    }
}
