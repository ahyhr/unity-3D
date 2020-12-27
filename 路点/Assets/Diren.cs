using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///
/// <summary>
public class Diren : MonoBehaviour 
{
    public GameObject[] Enemys;
   
    private void Start()
    {
        CalculateWaylines();
        for (int i = 0; i < 3; i++)
        {
            Invoke("shengchengdiren", 3);
        }
        
    }
   
    private void shengchengdiren()
    {
        WayLine[] usableWayline = SelectUsableWayline();
        WayLine line = usableWayline[Random.Range(0,usableWayline.Length)];
        int random = Random.Range(0, Enemys.Length);
        GameObject go = Instantiate(Enemys[random], line.WayPoints[0], Quaternion.identity) as GameObject;
        mada mada = go.GetComponent<mada>();
        mada.line = line;
    }


    private WayLine[] lines;
    /// <summary>
    /// 计算所有路线
    /// </summary>
    public void CalculateWaylines()
    {
        lines = new WayLine[transform.childCount];
        for (int i = 0; i < lines.Length; i++)
        {
            //每一个路线
            Transform wayLineTF = transform.GetChild(i);
            //创建路线对象
            lines[i] = new WayLine();
            lines[i].IsUsable = true;

            //创建路点数组对象
            lines[i].WayPoints = new Vector3[wayLineTF.childCount];
            for (int pointindex = 0; pointindex < wayLineTF.childCount; pointindex++)
            {
                //路点赋值
                lines[i].WayPoints[pointindex] = wayLineTF.GetChild(pointindex).position;
            }
        }
       
    }

    /// <summary>
    /// 选择所有可以使用的路线
    /// </summary>
    /// <returns></returns>
    private WayLine[] SelectUsableWayline()
    {
        List<WayLine> result = new List<WayLine>(lines.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IsUsable)
            {
                result.Add(lines[i]);
            }
        }
        return result.ToArray();
        //foreach (var item in lines)
        //{
        //    if (item.IsUsable)
        //    {
        //        result.Add(item);
        //    }
        //}
    }
}
