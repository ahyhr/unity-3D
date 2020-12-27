using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xunlu : MonoBehaviour 
{
    public Wayline line;
    private int index;
    private int le;
    private void Start()
    {
        le = line.waypoints.Length;
    }
    private void Update()
    {
        xl();
    }
    private void xl()
    {
        Vector3 fx=line.waypoints[index] - transform.position;
        Quaternion q=Quaternion.LookRotation(fx);
        transform.rotation=Quaternion.Lerp(transform.rotation, q, 2 * Time.deltaTime);

        transform.Translate(0, 0, 5 * Time.deltaTime);
        if (Vector3.Distance(transform.position,line.waypoints[index])<=0.3)
        {
            index++;
        }
        if (Vector3.Distance(transform.position,line.waypoints[le-1])<=0.3)
        {
            Destroy(this.gameObject,3f);
        }

    }

}
