using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunupdown : MonoBehaviour
{
    public float steer = 5;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("updown");
        if (Input.GetKey(KeyCode.Q) && ( (transform.localEulerAngles.x>=0&& transform.localEulerAngles.x<=20)|| (transform.localEulerAngles.x>=340&& transform.localEulerAngles.x<=360) || (transform.localEulerAngles.x>= -5 && transform.localEulerAngles.x<=5)))
        {
            transform.Rotate(-1 * steer * Time.deltaTime, 0, 0);
            /*
            if (transform.localEulerAngles.x > 20 && transform.localEulerAngles.x < 180){
                transform.localEulerAngles = new Vector3(19.91f, transform.localEulerAngles.y, transform.localEulerAngles.z); 
            } 
            */
        }
        if (transform.localEulerAngles.x > 20 && transform.localEulerAngles.x < 180){
                transform.localEulerAngles = new Vector3(19.91f, transform.localEulerAngles.y, transform.localEulerAngles.z); 
            }
        if (Input.GetKey(KeyCode.E)&& ( (transform.localEulerAngles.x>=0&& transform.localEulerAngles.x<=20)|| (transform.localEulerAngles.x>=340&& transform.localEulerAngles.x<=360) || (transform.localEulerAngles.x>= -5 && transform.localEulerAngles.x<=5)))
        {
            transform.Rotate(steer * Time.deltaTime,0 , 0);
            /*
            if (transform.localEulerAngles.x < 340 && transform.localEulerAngles.x > 180)  
            {  
                transform.localEulerAngles = new Vector3(340.11f, transform.localEulerAngles.y, transform.localEulerAngles.z);  
            } 
            */
        }
        if (transform.localEulerAngles.x < 340 && transform.localEulerAngles.x > 180)  
            {  
                transform.localEulerAngles = new Vector3(340.11f, transform.localEulerAngles.y, transform.localEulerAngles.z);  
            }
    }

}
