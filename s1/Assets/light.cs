using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class light : MonoBehaviour 
{
    private void Start()
    {
        GameObject gameob = new GameObject();
        gameob.name = "light";
        Light lig=gameob.AddComponent<Light>();
        lig.color = Color.red;
        lig.type = LightType.Directional;
       
    }



   

}
