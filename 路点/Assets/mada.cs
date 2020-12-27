using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class mada : MonoBehaviour 
{
    public WayLine line;
    private int index;
    public float speed=2;
    public float rotationSpeed=5;

    private void Update()
    {
        xunlu();
    }

    private void xunlu()
    {


        Vector3 vec=line.WayPoints[index] - transform.position;
        Quaternion qu=Quaternion.LookRotation(vec);
        transform.rotation=Quaternion.Lerp(transform.rotation, qu, rotationSpeed* Time.deltaTime);

        transform.Translate(0, 0, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position,line.WayPoints[index])<=0.2)
        {
            index++;
        }

    }
}
