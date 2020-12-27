using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
///
/// <summary>
public class text : MonoBehaviour 
{
    private Text textt;
    public int secend = 120;
    private float nextTime=1;
    private float  timee;
    private void Start()
    {
        textt=this.GetComponent<Text>();
        InvokeRepeating("xianshi", 0, 1);//重复调用的方法
    }
    private void Update()
    {
        if (secend==0)
        {
            CancelInvoke("xianshi");//取消重复调用
        }
        //if (Time.time>=nextTime)//定义1时间是否等于
        //{
        //    xianshi();
        //    nextTime = Time.time + 1;
        //}


        //timee += Time.deltaTime;//累加帧时间==1；
        //if (timee>=1)
        //{
        //    xianshi();
        //    timee = 0;
        //}
           
        
    }


    void xianshi()
    {
        secend--;
        textt.text = string.Format("{0:d2}:{1:d2}", secend / 60, secend % 60);
    }
}
