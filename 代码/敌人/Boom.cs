using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float ammoDetonationForce = 8000f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce((Vector3.up + new Vector3(Random.Range(0.1f, 0.3f), 0, Random.Range(0.05f, 0.2f)))
                    * Random.Range(ammoDetonationForce * 0.8f, ammoDetonationForce * 1.2f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
