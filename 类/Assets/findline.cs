using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class findline : MonoBehaviour 
{
    public GameObject[] LuXian;
    public float speed;
    private int index;

    private void Update()
    {
        XunLu();
    }
    private bool XunLu()
    {
        //如果路点为空 或索引大于路点数
        if (LuXian==null||index>=LuXian.Length)
        {
            return false;
        }

        //移动
        transform.Translate(0, 0, speed* Time.deltaTime);
        //旋转
        Vector3 pos=LuXian[index].transform.position - this.transform.position;
        Quaternion qua=Quaternion.LookRotation(pos);
        this.transform.rotation=Quaternion.Lerp(this.transform.rotation, qua, 3.5f*Time.deltaTime);
        //判断 寻找下一个路点
        if (Vector3.Distance(this.transform.position,LuXian[index].transform.position)<=0.1f)
        {
            index++;
        }
        return true;
    }

}
