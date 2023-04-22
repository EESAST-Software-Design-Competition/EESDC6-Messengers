using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewBehaviourScript1 : MonoBehaviour
{
    public float delayTime = 34; // 延时时间
    void Start()
    {
        StartCoroutine(LoadNextScene());
    }
    IEnumerator LoadNextScene()
    {
        // 延时指定时间
        yield return new WaitForSeconds(delayTime);
        // 加载下一个场景
        SceneManager.LoadScene(3);
    }
}
