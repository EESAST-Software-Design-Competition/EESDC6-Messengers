using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PlayerDestroyed : MonoBehaviour
{
    public Player player;
    //是否有坦克被击毁
    public bool isTankDestroyed = false;
    public bool isTankDestroyed2 = false;
    public GameObject fire;
    public GameObject explode;
    public Transform firep;
    public CanvasGroup screenMask;
    public CanvasGroup BailedOut;
    public CanvasGroup BailedOut2;
    private float maskAlpha;
    private float maskAlphaDuration =2f;
    public float totaltime = 5.0f;
    public GameObject bailedOutSmokeFx;
    public Transform bialedOutSmokeTrans;
    [HideInInspector]
    public bool isBailedOut;
    [HideInInspector]
    public bool isBailedOut2;
    [HideInInspector]
    public bool isBailedOut3;
    private void BailedOutOver()
    {
        isBailedOut = false;
    }

    private void Start()
    {
        isBailedOut = false;
        isBailedOut3 = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Delete))
        {
            this.totaltime -= Time.deltaTime;
            if (totaltime <= 0)
            {
                isTankDestroyed = true;
                isTankDestroyed2 = true;
                totaltime = 5.0f;
            }
        }
        if (isTankDestroyed)
        {
            this.GetComponent<Move>().enabled = false;
            maskAlpha += Time.deltaTime;
            screenMask.alpha = maskAlpha / maskAlphaDuration;
        }
        else
        {
            this.GetComponent<Move>().enabled = true;
        }
        if (isBailedOut)
        {
            this.GetComponent<Move>().enabled = false;
            BailedOut.alpha = 1;
            Debug.Log("按下P维修");
            if (Input.GetKey(KeyCode.P))
            {
                //按键按下时进行计时
                this.totaltime -= Time.deltaTime;
                if (totaltime <= 0)
                {
                    isBailedOut = false;
                    totaltime = 5.0f;
                }
            }
        }
        else if(isBailedOut3)
        {
            this.GetComponent<Move>().enabled = false;
            BailedOut2.alpha = 1;
            Debug.Log("按下P维修");
            if (Input.GetKey(KeyCode.P))
            {
                //按键按下时进行计时
                this.totaltime -= Time.deltaTime;
                if (totaltime <= 0)
                {
                    isBailedOut3 = false;
                    totaltime = 5.0f;
                }
            }
        }
        else
        {
            this.GetComponent<Move>().enabled = true;
            BailedOut.alpha = 0;
            BailedOut2.alpha = 0;
        }
        if(isTankDestroyed2)
        { 
            Instantiate(fire, firep.position, Quaternion.identity);
            Instantiate(explode, firep.position, Quaternion.identity);
            isTankDestroyed2 = false;
        }
        if(isBailedOut2)
        {
            Instantiate(bailedOutSmokeFx, bialedOutSmokeTrans.position, Quaternion.identity);
            isBailedOut2 = false;
        }
    }
}