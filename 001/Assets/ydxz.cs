using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class ydxz : MonoBehaviour 
{
    private void Update()
    {
        float hor=Input.GetAxis("Horizontal");
        float ver=Input.GetAxis("Vertical");
        if (hor!=0||ver!=0)
        {
            xz(hor, ver);
        }
        
    }
    private void xz(float hor,float ver)
    {
        Quaternion qu=Quaternion.LookRotation(new Vector3(hor, 0, ver));
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, qu, 20*Time.deltaTime);
        this.transform.Translate(0, 0, 2 * Time.deltaTime);
    }
}
