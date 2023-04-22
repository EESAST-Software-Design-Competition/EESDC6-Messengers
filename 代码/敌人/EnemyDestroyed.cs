using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyed : MonoBehaviour
{
    //�Ƿ���̹�˱�����
    public bool isTankDestroyed = false;
    //�Ƿ�Ϊѳ��
    public bool isAmmoDetonation = false;
    public float ammoDetonationForce = 800f;

    [HideInInspector]
    public Transform destroyedTank;
    [HideInInspector]
    public Transform destroyedTankTurretTrans;
    public Transform BoomTurret;

    //̹�˲к�Ԥ����
    public GameObject currentTankBody_AmmoDetonated;
    public GameObject currentTankDestroyed;
    public GameObject currentTankTurret_AmmoDetonated;
    // Start is called before the first frame update
    void Start()
    {
        isTankDestroyed = false;
        isAmmoDetonation = false;
        destroyedTank = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTankDestroyed)
        {
            if (isAmmoDetonation)
            {
                Transform body = destroyedTank.transform;
                Instantiate(currentTankBody_AmmoDetonated, body.position, body.rotation);
                Instantiate(currentTankTurret_AmmoDetonated, BoomTurret.position, BoomTurret.rotation);
                Destroy(destroyedTank.gameObject);
                isAmmoDetonation = false;
            }
            else
            {
                Instantiate(currentTankDestroyed, destroyedTank.position, destroyedTank.rotation);
                Destroy(destroyedTank.gameObject);
            }
            isTankDestroyed = false;
            destroyedTank = null;
        }
    }
}
