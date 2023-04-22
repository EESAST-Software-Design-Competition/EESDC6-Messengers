using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class say
{
    public string name;
    public string content;
}
public class 文本对话 : MonoBehaviour
{   
    public duihuakuangControl duihuakuang; 

    // Start is called before the first frame update
    say[] says;
    int index = 0;
    void Start()
    {//创建对话
        say say = new say() { name = "友方坦克", content = "你是来自……？" };
        say say1 = new say() { name = "你", content = "第X机械化军第X坦克营第XX连" }; 
        say say2 = new say() { name = "友方坦克", content = "哦，欢迎你的到来" };
        say say3 = new say() { name = "友方坦克", content = "你是来做什么的？" };
        say say4 = new say() { name = "你", content = "……………（讲述）" };
        say say5 = new say() { name = "友方坦克", content = "啊这，我们不是你要找的部队" };
        say say6 = new say() { name = "友方坦克", content = "但是我们可以给你换一辆坦克" };
        say say7 = new say() { name = "友方坦克", content = "美制的谢尔曼太难操作了" };

        says = new say[] { say, say1, say2,say3,say4, say5,say6,say7 };
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                if (index < says.Length)
                {
                    say say = says[index++];//显示对话
                    duihuakuang.ShowText(say.name, say.content);
                }   
            } 
       
    }
}
