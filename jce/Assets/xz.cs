using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xz : MonoBehaviour 
{
    public float speed=1;
    public float rspeed=20;

    private void Update()
    {
       float hor= Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor!=0||ver!=0)
        {
            XuanZhuan(hor, ver);
        }
        
    }



    private void XuanZhuan(float hor,float ver)
    {
        Quaternion dir= Quaternion.LookRotation(new Vector3(hor,0,ver));
        this.transform.rotation =Quaternion.Lerp(this.transform.rotation,dir,rspeed*Time.deltaTime);
        this.transform.Translate(0, 0, speed*Time.deltaTime);
    }
}
