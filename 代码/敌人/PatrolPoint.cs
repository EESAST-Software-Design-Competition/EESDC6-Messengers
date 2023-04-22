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
        if (enemyController != null &&//����Ѳ�ߵ�ᱻĳ������ʹ��
           enemyController.patrolIsActive &&//���˼�����Ѳ��
           enemyController.patrolPoint == this.transform &&//����Ŀǰ������ʻ���Ѳ�ߵ�
           enemyController.rotateComplete &&//�����Ѿ����ת��
           enemyController.moveComplete//�����Ѿ������ǰ�ƶ�
           )
        {
            if (nextPatrolpoint != null)
            {
                //����һ��Ѳ�ߵ����ø�����
                enemyController.patrolPoint = nextPatrolpoint;
                enemyController.moveComplete = false;
                enemyController.rotateComplete = false;
            }
            else
            {
                //���û����һ��Ѳ�ߵ㣬�ͱ���������Ϊ��Ѳ�ߵ�
                enemyController.patrolPoint = this.transform;
            }
        }
    }
}
