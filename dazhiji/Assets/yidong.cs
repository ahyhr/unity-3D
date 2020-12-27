using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class yidong : MonoBehaviour 
{
    private Vector3 tf;
    public AnimationCurve curve;
    private float x;
    private void Start()
    {
        tf = new Vector3(20, 0, 0);
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //匀速
            x += Time.deltaTime/3;
            transform.position=Vector3.MoveTowards(transform.position,tf,curve.Evaluate(x));
        }    
    }
    

}
