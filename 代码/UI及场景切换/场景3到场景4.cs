using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class 场景3到场景4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "3")
        {
            finish();
        }
    }
    void finish()
    {
        SceneManager.LoadScene(10);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
