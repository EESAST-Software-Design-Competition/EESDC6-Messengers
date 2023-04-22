
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GunShoot : MonoBehaviour {
 
    public GameObject bulletPrefab;  //子弹预制体
    public Transform gunPoint;
    private bool isLoaded;
    private bool startLoading;
    public float LoadTime = 5f;
    public GameObject Prefab;
    private void Loaded()
    {
        isLoaded = true;
    }
    void Start()
    {
        isLoaded = true;
        startLoading = false;
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))  //如果按下鼠标左键，生成预制体
        {
            if (isLoaded)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);  //生成预制体
                GameObject fire = Instantiate(Prefab, transform.position, transform.rotation);
                GameObject.Destroy(fire, 3f);
                GameObject.Destroy(bullet, 8f);
                isLoaded = false;
                startLoading = true;
            }
        }
        //装填弹药
        if (startLoading)
        {
            Invoke("Loaded", LoadTime);
            startLoading = false;
        }
    }
}