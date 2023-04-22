using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject impactFX;

    // ��������
    private TankDestroyed.DamageType FirePowerTest(Enemy enemy)
    {
        TankDestroyed.DamageType damage = TankDestroyed.DamageType.NoEffect;
        float firePower = Random.Range(2f, 7f);
        if (firePower < enemy.armor)
        {
            damage = TankDestroyed.DamageType.NoEffect;
        }
        else
        {
            if (firePower < enemy.armor + 1)
            {
                damage = TankDestroyed.DamageType.BailedOut;
            }
            else
            {
                if (firePower <= enemy.armor + 3)
                {
                    damage = TankDestroyed.DamageType.Destroyed;
                }
                else
                {
                    if (firePower > enemy.armor + 3)
                        damage = TankDestroyed.DamageType.AmmoDetonation;
                }
            }
        }

        return damage;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            // �˺��ж����ڵ��ű��н���
            TankDestroyed.DamageType damage = FirePowerTest(enemy);
            switch (damage)
            {
                case TankDestroyed.DamageType.NoEffect:
                    Debug.Log("NoEffect");
                    break;
                case TankDestroyed.DamageType.Destroyed:
                    enemy.tankDestroyed.isTankDestroyed = true;
                    enemy.tankDestroyed.isAmmoDetonation = false;
                    enemy.tankDestroyed.destroyedTank = enemy.transform;
                    break;
                case TankDestroyed.DamageType.AmmoDetonation:
                    enemy.tankDestroyed.isTankDestroyed = true;
                    enemy.tankDestroyed.isAmmoDetonation = true;
                    enemy.tankDestroyed.destroyedTank = enemy.transform;
                    enemy.tankDestroyed.destroyedTankTurretTrans = enemy.turret;
                    break;
            }

            if (damage == TankDestroyed.DamageType.NoEffect)
            {
                // û�в���Ч�����ڵ���������ɾ��
                Destroy(this.gameObject, 0.5f);
            }
            else
            {
                // ������Ч�����ڵ�����ɾ��
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject, 0.5f);
        }

        // ������Ч�� ���ɳ����Ч
        GameObject temp = Instantiate(impactFX, collision.contacts[0].point, Quaternion.FromToRotation(Vector3.up, collision.contacts[0].normal));
        Destroy(temp, 3f);
    }
}
