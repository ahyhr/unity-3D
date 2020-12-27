using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
///
/// <summary>
public class l1 
{
    public GameObject go;

    public l1(GameObject go)
    {
        this.go = go;
    }

    public void sc()
    {
        GameObject.Destroy(go, 2f);
    }
}
