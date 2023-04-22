using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleLift : MonoBehaviour
{
    public bool Isopen;
    public float totaltime = 4.0f;
    public GameObject pole;
    // Start is called before the first frame update
    void Start()
    {
        Isopen = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Isopen)
        { 
            pole.transform.Rotate(Vector3.up * 10f * Time.deltaTime, Space.Self);
            this.totaltime -= Time.deltaTime;
            if (totaltime <= 0)
            {
                Isopen = false;
                totaltime = 4.0f;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            Isopen = true;
        }
    }
}
