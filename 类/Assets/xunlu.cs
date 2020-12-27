using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xunlu : MonoBehaviour 
{
    public GameObject[] lx;
    private int index;
    public float speed=2;
    public float runspeed=5;

    private void Update()
    {
        xl();
        
    }

    private bool xl()
    {
        if (lx==null||index>=lx.Length)
        {
            return false;
        }
        transform.Translate(0, 0, runspeed*Time.deltaTime);

        Vector3 pos=lx[index].transform.position - this.transform.position;
        Quaternion fx=Quaternion.LookRotation(pos);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, fx, speed * Time.deltaTime);

        if (Vector3.Distance(this.transform.position,lx[index].transform.position)<=0.5)
        {
            index++;
        }

        return true;
    }
}
