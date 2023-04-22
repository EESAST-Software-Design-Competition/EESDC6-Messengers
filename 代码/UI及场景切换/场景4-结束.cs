using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class 场景4cg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "4")
        {
            finish();
        }
    }
    void finish()
    {
        SceneManager.LoadScene(13);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
