using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell3 : MonoBehaviour
{
    public GameObject impactFX;

    // ��������
    private TankDestroyed.DamageType FirePowerTest(Player2 player)
    {
        TankDestroyed.DamageType damage = TankDestroyed.DamageType.NoEffect;
        float firePower = Random.Range(2f, 7.5f);
        if (firePower < player.armor)
        {
            damage = TankDestroyed.DamageType.NoEffect;
        }
        else
        {
            if (firePower < player.armor + 1)
            {
                damage = TankDestroyed.DamageType.BailedOut;
            }
            else
            {
                if (firePower <= player.armor + 2)
                {
                    damage = TankDestroyed.DamageType.BailedOut;
                }
                else
                {
                    if (firePower > player.armor + 2)
                        damage = TankDestroyed.DamageType.Destroyed;
                }
            }
        }

        return damage;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player2 player = collision.gameObject.GetComponent<Player2>();
            // �˺��ж����ڵ��ű��н���
            TankDestroyed.DamageType damage = FirePowerTest(player);
            switch (damage)
            {
                case TankDestroyed.DamageType.NoEffect:
                    Debug.Log("NoEffect");
                    break;
                case TankDestroyed.DamageType.Destroyed:
                    player.tankDestroyed.isTankDestroyed = true;
                    player.tankDestroyed.isTankDestroyed2 = true;
                    break;
                case TankDestroyed.DamageType.BailedOut:
                    player.tankDestroyed.isBailedOut = true;
                    player.tankDestroyed.isBailedOut2 = true;
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
            Destroy(this.gameObject);
        }
        // ������Ч�� ���ɳ����Ч
        GameObject temp = Instantiate(impactFX, collision.contacts[0].point, Quaternion.FromToRotation(Vector3.up, collision.contacts[0].normal));
        Destroy(temp, 3f);
    }
}
