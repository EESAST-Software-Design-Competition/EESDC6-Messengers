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
    public Rigidbody rb;//̹�˸���
    public float rotateSpeed = 20f;
    public float moveSpeed = 3f;
    public float detectDistance = 50f;

    //Ѳ�߿���
    public float precision = 0.999f;
    [HideInInspector]
    public bool rotateComplete = false;
    [HideInInspector]
    public bool moveComplete = false;
    public bool canSeePlayer;

    //Ѳ�ߵ�
    public bool patrolIsActive = true;//Ѳ�ߵ��Ƿ񼤻�
    public Transform patrolPoint;//Ѳ�ߵ�,ʹ���ⲿ��GameObject.Transform
    private Transform patrolPointActived;//���������Ѳ�ߵ㣬������󽫱���ֵ

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

        //·���Ƿ񼤻�
        if(patrolIsActive)
        {
            patrolPointActived = patrolPoint;
        }
        else
        {
            patrolPointActived = null;
        }

        //ִ��Ѳ��
        if(patrolPointActived!=null)//�����Ѳ�ߵ�
        {
            Vector3 path = patrolPointActived.position - this.transform.position;
            Vector3 direction = new Vector3(path.x, 0f, path.z).normalized;

            //����ת��Ѳ�ߵ�ķ���
            if(transform.InverseTransformDirection(direction).z<=precision)
            {
                rotateComplete = false;
                float leftOrRight = Mathf.Sign(Vector3.Cross(transform.forward, direction).y);//��ת������ת��

                //ʵ����ת
                Quaternion turnRotation = Quaternion.Euler(0f, leftOrRight * rotateSpeed * Time.deltaTime, 0f);
                rb.MoveRotation(rb.rotation * turnRotation);

                //̹���Ĵ�����Ч��
                //����
                LeftTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(-leftOrRight * 0.06f * rotateSpeed * Time.deltaTime, 0);
                RightTrack.transform.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(-leftOrRight * 0.06f * rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                rotateComplete = true;
            }

            //��ת��ɺ����ƶ�̹��
            if(rotateComplete&&path.sqrMagnitude>=2f)
            { 
                moveComplete = false;
                //ʵ���ƶ�
                rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.deltaTime);

                //�Ĵ���ǰ
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
