using UnityEngine;
using System.Collections;

/// <summary>
///
/// <summary>
public class Bird : MonoBehaviour 
{
    private bool IsClick=false;
    public Transform rightPos;
    public float maxDis=3;
    [HideInInspector]
    public SpringJoint2D sp;
    private Rigidbody2D rg;

    public LineRenderer right;

    public LineRenderer left;
    public Transform leftpos;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
    }
    private void OnMouseDown()
    {
        IsClick = true;
        rg.isKinematic = true;
    }
    private void OnMouseUp()
    {
        IsClick = false;
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);
    }

    private void Update()
    {
        if (IsClick)
        {
            transform.position =Camera.main.ScreenToWorldPoint( Input.mousePosition);
            transform.position += new Vector3(0, 0, 10);
            if (Vector3.Distance(transform.position,rightPos.position)>maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }
            line();
        }
    }
    void Fly()
    {
        sp.enabled = false;
    }

    void line()
    {
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftpos.position);
        left.SetPosition(1, transform.position);
    }
}
