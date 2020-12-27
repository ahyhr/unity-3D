using UnityEngine;
using System.Collections;

/// <summary>
///Transform 类提供了查找（根，父，子）变换组件，改变位置，角度，大小功能
/// <summary>
public class tramsfrom : MonoBehaviour 
{
    public Transform tf;
    private void OnGUI()
    {
        
        if (GUILayout.Button("transforms"))
        {
            //每个子物体的变换组件

            foreach (Transform child in this.transform)
            {
                print(child.name);
                this.transform.position = new Vector3(5, 0, 0);
            }
        }
        if (GUILayout.RepeatButton("root"))
        {
            //获取根物体变换组件 cube
            Transform rootTf=this.transform.root;
        }
        if (GUILayout.RepeatButton("parent"))
        {
            //获取父物体的transform
            Transform parentTF =this.transform.parent;
        }
        if (GUILayout.RepeatButton("setparent"))
        {
            //当前物体位置 视为世界坐标
            //this.transform.SetParent(tf,true);
            //当前物体位置 视为自身坐标
            this.transform.SetParent(tf,false);
        }

        if (GUILayout.Button("foreach-transforms"))
        {
            //物体相对于世界坐标系原点的位置
            //this.transform.position
            //物体相对于父物体轴心点的位置
            //this.transform.localPosition


            //相对于父物体缩放比例 1 2 1
            //this.transform.localScale
            //理解为父物体缩放比例*当前物体缩放比例
            //this.transform.lossyScale
        }

        if (GUILayout.Button("find"))
        {
            //查找物体
            //Transform find=this.transform.Find("子物体名称");
            Transform find = this.transform.Find("子物体名称/子物体名称");         

        }
            if (GUILayout.Button("pos/scale"))
        {
            //向自身坐标系 移动   Translate       世界 Space.World
            //this.transform.Translate(0, 0, 1);
            //向世界坐标系 移动
            this.transform.Translate(0, 0, 1, Space.World);
        }
        if (GUILayout.Button("rotate"))
        {
            // 自身坐标系旋转 Rotate  
            //this.transform.Rotate(0, 0, 10);
            // 世界坐标系旋转
            this.transform.Rotate(0, 0, 10,Space.World);
        }
        if (GUILayout.RepeatButton("RotateAround"))
        {
            this.transform.RotateAround(Vector3.zero, Vector3.forward, 1);//点，方向，角度
            
        }


    }

}
