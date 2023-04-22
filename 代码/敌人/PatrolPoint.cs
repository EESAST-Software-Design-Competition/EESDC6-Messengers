using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public patrol enemyController = null;
    public Transform nextPatrolpoint = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController != null &&//当该巡逻点会被某个敌人使用
           enemyController.patrolIsActive &&//敌人激活了巡逻
           enemyController.patrolPoint == this.transform &&//敌人目前正在行驶向该巡逻点
           enemyController.rotateComplete &&//敌人已经完成转向
           enemyController.moveComplete//敌人已经完成向前移动
           )
        {
            if (nextPatrolpoint != null)
            {
                //将下一个巡逻点设置给敌人
                enemyController.patrolPoint = nextPatrolpoint;
                enemyController.moveComplete = false;
                enemyController.rotateComplete = false;
            }
            else
            {
                //如果没有下一个巡逻点，就保持这设置为该巡逻点
                enemyController.patrolPoint = this.transform;
            }
        }
    }
}
