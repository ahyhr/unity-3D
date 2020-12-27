using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class cube : MonoBehaviour 
{
    //public Transform tf;

    //private void OnGUI()
    //{
    //    if (GUILayout.Button("1"))
    //    {
    //        this.transform.SetParent(tf);
    //    }
       
    //}

    private void Digui(Transform a)
    {
        Transform childTransform = this.transform.Find("名称");
        if (a==childTransform)
        {
            return;
        }
        else
        {
            int count = this.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                transform.GetChild(i);
            }
        }
        
    }
    
}
