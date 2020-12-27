using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class look : MonoBehaviour 
{
    public GameObject cub;
    private void Update()
    {
        Vector3 ve=cub.transform.position - transform.position;
        transform.rotation=Quaternion.FromToRotation(Vector3.right, ve);
        
        
    }

}
