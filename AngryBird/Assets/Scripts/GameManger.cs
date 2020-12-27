using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///
/// <summary>
public class GameManger : MonoBehaviour 
{
    public List<Bird> birds;
    public List<Pig> pigs;
    public static GameManger instance;

    private void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 初始化小鸟
    /// </summary>
    private void Initialized()
    {
        for (int i = 0; i<birds.Count; i++)
        {
            if (i==0)//第一只小鸟
            {
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }
}
