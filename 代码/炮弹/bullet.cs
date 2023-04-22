
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bullet : MonoBehaviour {
    public float speed = 16f;  //子弹速度
 
	void Start () {
        //Destroy(gameObject, 7f);  //7s后销毁自身
    }
	
	void Update () {
        
        transform.Translate(0, Time.deltaTime * speed, 0);  //子弹位移
	}
 
}