using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class fx : MonoBehaviour 
{
    public AnimationCurve curve;
    private float x;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            yidong();
        }
    }
    private void yidong()
    {
        x += Time.deltaTime/3;
        Vector3 to=new Vector3(10, 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, to,curve.Evaluate(x));
        
    }
}
