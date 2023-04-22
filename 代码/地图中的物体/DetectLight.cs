using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLight : MonoBehaviour
{
    public float totaltime = 3.5f;
    public bool fire;
    public GameObject shell1;
    public Transform shellp1;
    public GameObject shell2;
    public Transform shellp2;
    public GameObject shell3;
    public Transform shellp3;
    public GameObject shell4;
    public Transform shellp4;
    public GameObject shell5;
    public Transform shellp5;
    // Start is called before the first frame update
    void Start()
    {
        fire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire == false)
        {
            this.totaltime -= Time.deltaTime;
            if (totaltime <= 0)
            {
                fire = true;
                totaltime = 3.5f;
            }
        }
        if(fire)
        {
            GameObject bullet1 = Instantiate(shell1, shellp1.position, Quaternion.identity);
            GameObject.Destroy(bullet1, 5f);
            GameObject bullet2 = Instantiate(shell2, shellp2.position, Quaternion.identity);
            GameObject.Destroy(bullet2, 5f);
            GameObject bullet3 = Instantiate(shell3, shellp3.position, Quaternion.identity);
            GameObject.Destroy(bullet3, 5f);
            GameObject bullet4 = Instantiate(shell4, shellp4.position, Quaternion.identity);
            GameObject.Destroy(bullet4, 5f);
            GameObject bullet5 = Instantiate(shell5, shellp5.position, Quaternion.identity);
            GameObject.Destroy(bullet5, 5f);
            fire = false;
        }
    }
}
