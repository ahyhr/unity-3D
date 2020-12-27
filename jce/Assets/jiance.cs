using UnityEngine;
using System.Collections;


/// <summary>
///
/// <summary>
/// 
public class jiance : MonoBehaviour 
{
    public GameObject player;
    private float playerRadius;
    private Vector3 left;
    private Vector3 right;
    private void Start()
    {
        playerRadius = player.GetComponent<CapsuleCollider>().radius;
    }


    private void Update()
    {
        JianCeff();
    }

    private void JianCeff()
    {
        Vector3 red=this.transform.position - player.transform.position;
        Vector3 green = red.normalized * playerRadius;
        float angle = Mathf.Acos(playerRadius / red.magnitude) * Mathf.Rad2Deg;
        left = player.transform.position+Quaternion.Euler(0, -angle, 0)*green;
        right = player.transform.position + Quaternion.Euler(0, angle, 0) * green;

        Debug.DrawLine(this.transform.position, left);
        Debug.DrawLine(this.transform.position, right);
    }
}
