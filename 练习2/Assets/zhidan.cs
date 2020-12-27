using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class zhidan : MonoBehaviour 
{
    private Vector3 pos;
    public float speed=100;
    public LayerMask mask;
    private void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,200,mask))
        {
            pos = hit.point;
        }
        else
        {
            pos = transform.position+Vector3.forward * 200;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        if ((transform.position-pos).sqrMagnitude<=0.02)
        {
            Destroy(this.gameObject,0.1f);
        }

    }

    private void OnCollisionEnter(Collision dir)
    {
        print(dir.collider.name);
        hp hp=dir.collider.GetComponent<hp>();
        hp.hps -= 2;
    }
}
