using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunpoint : MonoBehaviour
{
    public GameObject bulletPrefab;  //子弹预制体
    public GameObject Prefab;
    public Transform gunPoint;
    private bool isLoaded;
    private bool startLoading;
    public bool AimedAtPlayer;
    public bool LightIsOn;
    public float LoadTime = 5f;
    public float detectDistance = 50f;
    private void Loaded()
    {
        isLoaded = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        isLoaded = true;
        startLoading = false;
        LightIsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (LightIsOn)
            {
                LightIsOn = false;
            }
            else
            {
                LightIsOn = true;
            }
        }
        if (Physics.Raycast(gunPoint.position, -gunPoint.up, out hit, detectDistance))
        {
            if (hit.transform.tag == "Player")
            {
                AimedAtPlayer = true;
            }
            else
            {
                AimedAtPlayer = false;
            }
        }
        else
        {
            AimedAtPlayer = false;
        }
        //开火
        if (AimedAtPlayer&&LightIsOn)
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
