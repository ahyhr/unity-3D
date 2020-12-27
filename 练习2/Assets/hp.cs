using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class hp : MonoBehaviour 
{
    public int hps=5;
    public GameObject cyli;
    private void Update()
    {
        
        if (hps<=0)
        {
            Destroy(this.gameObject);
            GameObject go=Instantiate(cyli, transform.position, Quaternion.identity)as GameObject;
            Destroy(go, 2f);
        }
        
    }
}
