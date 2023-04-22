using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public bool LightIsOn;
    public GameObject light1;
    public GameObject light2;
    // Start is called before the first frame update
    void Start()
    {
        LightIsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        { if(LightIsOn)
            { 
                light1.SetActive(false);
                light2.SetActive(false);
                LightIsOn = false;
            }
            else
            {
                light1.SetActive(true);
                light2.SetActive(true);
                LightIsOn = true;
            }
        }
    }
}
