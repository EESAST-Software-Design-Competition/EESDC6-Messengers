using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class duihuakuangControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }//更改显示文本
    public void ShowText(string name,string content)
    {
        transform.GetChild(0).GetComponent<Text>().text = name;
        transform.GetChild(1).GetComponent<Text>().text = content;
    }
    void Update()
    {
        
    }
}
