using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class Component : MonoBehaviour 
{
    public float time;

    private void Update()
    {
        int a = 1;
        int b = 2;
        int c = a + b;
        //time =Time.time;
       
    }

    private void OnGUI()
    {

        if (GUILayout.Button("transform"))
        {
            print("ok");
            this.transform.position = new Vector3(0, 0, 10);
        }

        if (GUILayout.Button("GetComponent"))
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        if (GUILayout.Button("GetComponents"))//获取当前物体所有组件
        {
            var allCompoment = this.GetComponents<Component>();        
            foreach (var item in allCompoment)
            {
                print(item);
            }
        }

        if (GUILayout.Button("GetComponentsInChildren"))
        {
            //获取后代物体的指定类型组件（从自身开始) 从上到下查找
            var allCompoments = this.GetComponentsInChildren<MeshRenderer>();

            //获取先辈物体的指定类型组件（从自身开始)  GetComponentsInParent   从下到上查找
            //var allCompoments = this.GetComponentsInParent<MeshCollider>();
            foreach (var item in allCompoments)
            {
                item.material.color = Color.red;
            }
        }
       
    }

}
