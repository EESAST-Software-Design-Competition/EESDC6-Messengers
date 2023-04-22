using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunpoint : MonoBehaviour
{
    public GameObject bulletPrefab;  //�ӵ�Ԥ����
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
        //����
        if (AimedAtPlayer&&LightIsOn)
        {
            if (isLoaded)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);  //����Ԥ����
                GameObject fire = Instantiate(Prefab, transform.position, transform.rotation);
                GameObject.Destroy(fire, 3f);
                GameObject.Destroy(bullet, 8f);
                isLoaded = false;
                startLoading = true;
            }
        }
        //װ�ҩ
        if (startLoading)
        {
            Invoke("Loaded", LoadTime);
            startLoading = false;
        }
    }
}
