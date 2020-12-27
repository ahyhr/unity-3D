using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class yid : MonoBehaviour 
{
    public GameObject to;
    private Vector3 toTF;
    public AnimationCurve curve;
    private float time;
    private Vector3 fromTF;
    private void Start()
    {
        toTF = to.transform.position;
        fromTF = this.transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            quxyd();
        }
           
        
       
      
    }

    private void YiDong()
    {
        toTF = new Vector3(0, 0, 5);
        this.transform.position = Vector3.MoveTowards(this.transform.position,toTF, 0.1f);


    }

    private void quxyd()
    {
        time += Time.deltaTime/4;
        this.transform.position=Vector3.Lerp(fromTF, toTF, curve.Evaluate(time));

    }
}
