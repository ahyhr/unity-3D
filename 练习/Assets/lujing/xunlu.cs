using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xunlu : MonoBehaviour 
{
    public Wayline line;
    private int index;
    public float rospeed=5;
    public float movespeed = 10;

    private void Update()
    {
        xl();
    }
    private void xl()
    {
        Vector3 fx=line.Waypoints[index] - transform.position;
        Quaternion qu=Quaternion.LookRotation(fx);
        transform.rotation=Quaternion.Lerp(transform.rotation, qu, rospeed * Time.deltaTime);
        transform.Translate(0, 0, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position,line.Waypoints[index])<=0.2)
        {
            index++;
        }
        if (Vector3.Distance(transform.position, line.Waypoints[line.Waypoints.Length-1]) <= 0.2)
        {
            Destroy(gameObject,2);
        }
    }

}
