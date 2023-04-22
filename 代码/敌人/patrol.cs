using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    public GameObject LeftTrack;
    public GameObject RightTrack;
    public Transform watchTower;
    public Transform aimmingPosition;
    public Rigidbody rb;//坦克刚体
    public float rotateSpeed = 20f;
    public float moveSpeed = 3f;
    public float detectDistance = 50f;

    //巡逻控制
    public float precision = 0.999f;
    [HideInInspector]
    public bool rotateComplete = false;
    [HideInInspector]
    public bool moveComplete = false;
    public bool canSeePlayer;

    //巡逻点
    public bool patrolIsActive = true;//巡逻点是否激活
    public Transform patrolPoint;//巡逻点,使用外部的GameObject.Transform
    private Transform patrolPointActived;//如果激活了巡逻点，这个对象将被赋值

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rotateComplete = false;
        moveComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(watchTower.position,aimmingPosition.position-watchTower.position,out hit,detectDistance))
        {
            if (hit.transform.tag == "Player")
            {
                canSeePlayer = true;
            }
            else 
            { 
                canSeePlayer = false; 
            }
        }
        else
        {
            canSeePlayer = false;
        }

        //路径是否激活
        if(patrolIsActive)
        {
            patrolPointActived = patrolPoint;
        }
        else
        {
            patrolPointActived = null;
        }

        //执行巡逻
        if(patrolPointActived!=null)//如果有巡逻点
        {
            Vector3 path = patrolPointActived.position - this.transform.position;
            Vector3 direction = new Vector3(path.x, 0f, path.z).normalized;

            //首先转向巡逻点的方向
            if(transform.InverseTransformDirection(direction).z<=precision)
            {
                rotateComplete = false;
                float leftOrRight = Mathf.Sign(Vector3.Cross(transform.forward, direction).y);//左转还是右转？

                //实际旋转
                Quaternion turnRotation = Quaternion.Euler(0f, leftOrRight * rotateSpeed * Time.deltaTime, 0f);
                rb.MoveRotation(rb.rotation * turnRotation);

                //坦克履带滚动效果
                //左右
                LeftTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(-leftOrRight * 0.06f * rotateSpeed * Time.deltaTime, 0);
                RightTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(-leftOrRight * 0.06f * rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                rotateComplete = true;
            }

            //旋转完成后再移动坦克
            if(rotateComplete&&path.sqrMagnitude>=2f)
            { 
                moveComplete = false;
                //实际移动
                rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.deltaTime);

                //履带向前
                LeftTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(0.1f * rotateSpeed * Time.deltaTime, 0);
                RightTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(0.1f * rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                moveComplete = true;
            }
        }
    }
}
