using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomTime : MonoBehaviour
{
    public Transform InPoint;
    private bool isLoaded;
    private bool startLoading;
    public float LoadTime = 30f;
    public GameObject Spark;
    // Start is called before the first frame update
    void Start()
    {
        isLoaded = true;
        startLoading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoaded)
        {
            GameObject fire = Instantiate(Spark, InPoint.position, InPoint.rotation);
            GameObject.Destroy(fire, 30f);
            isLoaded = false;
            startLoading = true;
        }
        if (startLoading)
        {
            Invoke("Loaded", LoadTime);
            startLoading = false;
        }
    }
}
