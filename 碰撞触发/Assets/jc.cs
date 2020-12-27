using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class jc : MonoBehaviour 
{
    public float moveSpeed=100;
    private Vector3 point;
    private RaycastHit hhit;
    private void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,100))
        {
            point=hit.point;
            hhit = hit;
        }
        else
        {
            point = transform.position+Vector3.forward * 100;
        }
    }

    private void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position, point, moveSpeed * Time.deltaTime);
        if ((transform.position-point).sqrMagnitude<=0.1)
        {
            Destroy(gameObject,2);
            Destroy(hhit.collider.gameObject);
        }
    }

}
