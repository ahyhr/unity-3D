using UnityEngine;
using System.Collections;

/// <summary>
///变换组件助手类
/// <summary>
public class TransformHelper
{/// <summary>
/// 在未知层级查找子物体
/// </summary>
/// <param name="parentTF">父物体变换组件</param>
/// <param name="childName">子物体名字</param>
/// <returns></returns>
    public static Transform GetChild(Transform parentTF,string childName)
    {
        //在子物体中查找
        Transform chileTF=parentTF.Find(childName);
        if (chileTF!=null)
        {
            return chileTF;
        }

        int count = parentTF.childCount;
        for (int i = 0; i < count; i++)
        {
            chileTF=GetChild(parentTF.GetChild(i), childName);
            if (chileTF != null)
            {
                return chileTF;
            }
        }
        return null;
    }

}
