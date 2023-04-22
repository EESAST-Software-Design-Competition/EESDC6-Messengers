using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 进水瘫痪 : MonoBehaviour
{
    private TankDestroyed.DamageType FirePowerTest(Player player)
    {
        TankDestroyed.DamageType damage = TankDestroyed.DamageType.NoEffect;
        float firePower = 4.5f;
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
            Player player = collision.gameObject.GetComponent<Player>();
            // 伤害判定在炮弹脚本中进行
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
                    player.tankDestroyed.isBailedOut2 = true;
                    player.tankDestroyed.isBailedOut3 = true;
                    break;
            }

            if (damage == TankDestroyed.DamageType.NoEffect)
            {
                // 没有产生效果，炮弹不能立刻删除
                Destroy(this.gameObject, 0.5f);
            }
            else
            {
                // 产生了效果，炮弹立刻删除
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.tag == "GameManager")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }  
    }
}
