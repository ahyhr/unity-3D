using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class xunlu : MonoBehaviour 
{
    public Wayline line;
    private int index;
    private int index2;
    private void Start()
    {
        index2 = line.waypoints.Length;
    }
    private void Update()
    {
        xl();
    }
    private void xl()
    {
        Vector3 ve=line.waypoints[index] - transform.position;
        Quaternion qu=Quaternion.LookRotation(ve);
        transform.rotation=Quaternion.Lerp(transform.rotation, qu, 2 * Time.deltaTime);
        transform.Translate(0, 0, 5 * Time.deltaTime);
        if (Vector3.Distance(transform.position,line.waypoints[index])<=0.2)
        {
            index++;
        }
        if (Vector3.Distance(transform.position, line.waypoints[index2-1]) <= 0.2)
        {
            Destroy(this.gameObject,2);
        }
    }

}
