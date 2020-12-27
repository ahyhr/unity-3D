using UnityEngine;
using System.Collections;
using System;

/// <summary>
///
/// <summary>
public class GameObject : MonoBehaviour 
{


    private void OnGUI()
    {
        //在场景中物体激活状态（物体实际激活状态）
        //this.gameObject.activeInHierarchy
        //物体自身激活状态（物体在面板上的状态）
        // this.gameObject.activeSelf
        //设置物体禁用或启用
        //this.gameObject.SetActive()

        if (GUILayout.Button("添加"))
        {
            GameObject Player = new GameObject();
            Light light=Player.gameObject.AddComponent<Light>();
                      
        }
    }
    
}
