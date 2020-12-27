using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
///
/// <summary>
public class l2 : MonoBehaviour 
{
    public GameObject go;
    private l1 aa;
    private void Awake()
    {
        aa = new l1(go);
    }

    private void Update()
    {
        aa.sc();
    }
}
