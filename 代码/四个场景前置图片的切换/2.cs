using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewBehaviourScript1 : MonoBehaviour
{
    public float delayTime = 34; // ��ʱʱ��
    void Start()
    {
        StartCoroutine(LoadNextScene());
    }
    IEnumerator LoadNextScene()
    {
        // ��ʱָ��ʱ��
        yield return new WaitForSeconds(delayTime);
        // ������һ������
        SceneManager.LoadScene(3);
    }
}
