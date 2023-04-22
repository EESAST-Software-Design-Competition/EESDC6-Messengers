using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{ 
    public void 开场CG()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(0);
    }
   public void 开始界面()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(1);
    }
    public void 场景一()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(2);
    }
    public void 场景二()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(3);
    }
    public void 场景三()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(5);
    }
    public void 进度条()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(4);
    } 
    public void 场景二文字()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(6);
    }
    public void 场景四()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(11);
    }
    public void 场景1前置()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(7);
    }
    public void 场景2前置()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(8);
    }
    public void 场景3前置()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(9);
    }
    public void 场景4前置()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(10);
    }
    public void 选择关卡()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(12);
    }
    public void 结束CG()//切换场景并销毁原场景//
    {
        SceneManager.LoadScene(13);
    }
    public void myExit()//退出函数//
    {
        Application.Quit();
    }
}
