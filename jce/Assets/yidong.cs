using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class yidong : MonoBehaviour 
{
    private Vector3 newVector = new Vector3(0, 0, 10);
    public float speed = 0.1f;
    public AnimationCurve curve;
    private float sp=0;
    public float time=1;
    private void Update()
    {
        //匀速移动
        if (Input.GetMouseButton(0))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, newVector, speed);
        }

        //变速移动
        if (Input.GetMouseButton(1))
        {
            sp += Time.deltaTime / time;
            //Vector3.LerpUnclamped可超过终点（1）会返回
            //Vector3.Lerp不会超过终点
            this.transform.position = Vector3.Lerp(Vector3.zero, newVector,curve.Evaluate(sp));
        }



    }
}
