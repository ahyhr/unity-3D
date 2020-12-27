using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xuanzhuan : MonoBehaviour 
{
    public GameObject cub;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor!=0||ver!=0)
        {
            yd(hor, ver);
        }
        
        if (Input.GetMouseButton(1))
        {
            xzx();
        }
    }

    private void yd(float hor,float ver)
    {
        Quaternion ro=Quaternion.LookRotation(new Vector3(hor, 0, ver));
        Quaternion le=Quaternion.Lerp(transform.rotation, ro, 0.2f);
        this.transform.rotation = le;
        transform.Translate(0,0,4*Time.deltaTime);
    }

    private void xz()
    {
        //匀速旋转
        Vector3 dir = cub.transform.position - this.transform.position; 
        Quaternion qua = Quaternion.LookRotation(dir);
        transform.rotation=Quaternion.RotateTowards(transform.rotation, qua, 1f);
    }
    private void xzjb()
    {
        //差值旋转
        Vector3 dir = cub.transform.position - this.transform.position;
        Quaternion qua = Quaternion.LookRotation(dir);
        transform.rotation=Quaternion.Lerp(transform.rotation, qua,0.05f);
        if (Quaternion.Angle(transform.rotation,qua)<=10)
        {
            transform.rotation = qua;
        }
    }

    private void xzx()
    {
        //x轴注视旋转  FromToRotation 
        Vector3 dir = cub.transform.position - this.transform.position;
        Quaternion qua=Quaternion.FromToRotation(Vector3.right, dir);
        transform.rotation=Quaternion.Lerp(transform.rotation, qua, 0.05f);
        if (Quaternion.Angle(transform.rotation,qua)<=1)
        {
            transform.rotation = qua;
        }
    }
}
